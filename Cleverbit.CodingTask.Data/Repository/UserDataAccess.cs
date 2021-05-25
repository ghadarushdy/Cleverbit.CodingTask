using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.Data
{
    public class UserDataAccess : BaseDataAccess<User, int>, IUserDataAccess
    {
        public UserDataAccess(CodingTaskContext _Context) : base(_Context)
        {

        }
    }
}
