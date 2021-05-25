using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.BLL
{
    public class ServiceOutput
    {
        public Status Status { get; set; }
        public string StatusMessage { get; set; }
        public string WinnerName { get; set; }
        public List<MatchesWinners> MatchesWinners { get; set; }
        public bool IsAuthenticated { get; set; }

        public ActiveMatch ActiveMatch { get; set; }
    }

    public enum Status
    {
        Success=1,
        Failed
    }

    public class MatchesWinners
    {
        public string MatchName { get; set; }
        public string WinnerName { get; set; }
    }

    public class ActiveMatch
    {
        public int MatchId { get; set; }
        public string MatchName { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
