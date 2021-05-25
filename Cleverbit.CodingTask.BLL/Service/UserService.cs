using Cleverbit.CodingTask.Data;
using Cleverbit.CodingTask.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.BLL
{
    public class UserService : IUserService
    {
        private readonly IHashService _hashService;
        private readonly IUserDataAccess _userDataAccess;

        public UserService(IHashService hashService, IUserDataAccess userDataAccess)
        {
            _hashService = hashService;
            _userDataAccess = userDataAccess;
        }


        public ServiceOutput AuthenticateUser(string userName, string password)
        {
            try
            {
                var hashPassword = _hashService.HashText(password);
                var user = _userDataAccess.FindByQueryNotTracked(e=> e.UserName == userName && e.Password== hashPassword.Result);

                if(user !=null)
                return new ServiceOutput()
                {
                    Status = Status.Success,
                    StatusMessage = "Success",
                   IsAuthenticated= true
                };

                return new ServiceOutput()
                {
                    Status = Status.Success,
                    StatusMessage = "Success",
                    IsAuthenticated = false
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
    }
}
