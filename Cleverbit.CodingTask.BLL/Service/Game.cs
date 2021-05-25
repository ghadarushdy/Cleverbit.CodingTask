using Cleverbit.CodingTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cleverbit.CodingTask.BLL
{
    public class Game : IGame
    {
        private GenerateRandomNumber Generate = GenerateRandomNumber.Instance;
        private readonly IMatchDataAccess _matchDataAccess;
        private readonly IMatchUsersNumbersDataAccess _matchUsersNumbersDataAccess;
        private readonly IUserDataAccess _userDataAccess;       

        public Game(IMatchDataAccess matchDataAccess, IMatchUsersNumbersDataAccess matchUsersNumbersDataAccess,
            IUserDataAccess userDataAccess)
        {
            _matchDataAccess = matchDataAccess;
            _matchUsersNumbersDataAccess = matchUsersNumbersDataAccess;
            _userDataAccess = userDataAccess;           
        }

        public int GenerateNumber(int max)
        {
            try
            {
                return Generate.GetRandomNumber(max);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public ServiceOutput GetWinner(int matchId)
        {
            try
            {
                var match = _matchDataAccess.GetById(matchId);

                if (match is null)
                    return new ServiceOutput()
                    {
                        Status = Status.Failed,
                        StatusMessage = "No match found with this Id"
                    };

                var expireTime = match.Timestamp;

                if (expireTime >= DateTime.Now) // get the winner
                {
                    var usersRandomNumbers = _matchUsersNumbersDataAccess.FindAllByQueryNotTracked(e => e.MatchId == matchId);  //match.UserNumbers.ToList();                   

                    var winnerUser = usersRandomNumbers.Find(e => e.RandomNumber == usersRandomNumbers.Max(e => e.RandomNumber));

                    var winnerUserName = _userDataAccess.GetById(winnerUser.UserId).UserName;

                    match.WinningUserName = winnerUserName;
                    _matchDataAccess.Update(match);

                    return new ServiceOutput()
                    {
                        Status = Status.Success,
                        StatusMessage = "Success",
                        WinnerName = winnerUserName
                    };
                }

                return new ServiceOutput()
                {
                    Status = Status.Failed,
                    StatusMessage = "Match time not expired yet"
                };
            }
            catch (Exception ex)
            {
                //log here later


                // return
                return new ServiceOutput()
                {
                    Status = Status.Failed,
                    StatusMessage = "Failed"
                };
            }
        }

        public ServiceOutput SaveUserRandomNumber(UserMatchGeneratedNumber userMatchGeneratedNumber)
        {
            try
            {
                var match = _matchDataAccess.GetById(userMatchGeneratedNumber.MatchId);

                if (match is null)
                    return new ServiceOutput()
                    {
                        Status = Status.Failed,
                        StatusMessage = "No match found with this Id"
                    };

                var user = _userDataAccess.FindByQueryNotTracked(e => e.UserName == userMatchGeneratedNumber.UserName);

                if (user is null)
                    return new ServiceOutput()
                    {
                        Status = Status.Failed,
                        StatusMessage = "User not exist in the system"
                    };

                MatchUsersNumbers matchUsersNumbers = _matchUsersNumbersDataAccess.FindByQueryNotTracked(e => e.MatchId == userMatchGeneratedNumber.MatchId && e.UserId == _userDataAccess.FindByQueryNotTracked(e => e.UserName == userMatchGeneratedNumber.UserName).Id);

                if (matchUsersNumbers != null)
                    return new ServiceOutput()
                    {
                        Status = Status.Failed,
                        StatusMessage = "User already submitted his number"
                    };

                MatchUsersNumbers userNumber = new MatchUsersNumbers()
                {
                    RandomNumber = userMatchGeneratedNumber.GeneratedNumber,
                    MatchId = userMatchGeneratedNumber.MatchId,
                    UserId = user.Id
                };

                int rows = _matchUsersNumbersDataAccess.Add(userNumber);

                if (rows == 1) // number of affected rows
                    return new ServiceOutput()
                    {
                        Status = Status.Success,
                        StatusMessage = ""
                    };

                return new ServiceOutput()
                {
                    Status = Status.Failed,
                    StatusMessage = "Failed to save user generated number"
                };

            }
            catch (Exception ex)
            {
                //log here later


                //return

                return new ServiceOutput()
                {
                    Status = Status.Failed,
                    StatusMessage = "Failed to save user generated number"
                };
            }
        }

        public ServiceOutput GetAllMatchesWinners()
        {
            try
            {
               var matchesWinnersList =  _matchDataAccess.GetAllNotTracked().Select(e => new MatchesWinners()
                {
                   MatchName = e.MatchName,
                   WinnerName = e.WinningUserName

                }).ToList();


                return new ServiceOutput()
                {
                    Status = Status.Success,
                    StatusMessage = "Success",
                    MatchesWinners = matchesWinnersList
                };
            }
            catch (Exception ex)
            {
                //log here

                //return
                return new ServiceOutput()
                {
                    Status = Status.Failed,
                    StatusMessage = "Failed to load matches winners"
                };
            }
        }

        public ServiceOutput GetActiveMatch()
        {
            try
            {
               Match match= _matchDataAccess.FindByQueryNotTracked(e=> e.IsActive==true);

                return new ServiceOutput()
                {
                    Status = Status.Success,
                    StatusMessage = "Success",
                    ActiveMatch = new ActiveMatch()
                    {
                        ExpireDate = match.Timestamp,
                        MatchId = match.Id,
                        MatchName = match.MatchName
                    }
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
