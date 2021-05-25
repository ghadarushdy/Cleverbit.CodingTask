using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.BLL
{
    public interface IUserService
    {
        ServiceOutput AuthenticateUser(string userName, string password);
    }
}
