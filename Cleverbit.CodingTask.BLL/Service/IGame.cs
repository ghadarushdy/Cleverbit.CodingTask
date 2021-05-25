using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.BLL
{
   public interface IGame
    {
        int GenerateNumber(int max);
        ServiceOutput GetWinner(int matchId);
        ServiceOutput SaveUserRandomNumber(UserMatchGeneratedNumber userMatchGeneratedNumber);
        ServiceOutput GetAllMatchesWinners();
        ServiceOutput GetActiveMatch();
    }
}
