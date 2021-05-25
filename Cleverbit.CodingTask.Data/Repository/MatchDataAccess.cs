using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.Data
{
    public class MatchDataAccess : BaseDataAccess<Match, int>, IMatchDataAccess
    {
        public MatchDataAccess(CodingTaskContext _Context) : base(_Context)
        {

        }
    }
}
