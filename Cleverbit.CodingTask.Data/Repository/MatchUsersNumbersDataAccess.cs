using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.Data
{
    public class MatchUsersNumbersDataAccess : BaseDataAccess<MatchUsersNumbers, int>, IMatchUsersNumbersDataAccess
    {
        public MatchUsersNumbersDataAccess(CodingTaskContext _Context) : base(_Context)
        {

        }
    }
}
