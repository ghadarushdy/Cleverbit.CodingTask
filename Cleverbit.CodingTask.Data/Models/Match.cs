using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cleverbit.CodingTask.Data
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
        public int? UserNumbersId { get; set; }
        public string MatchName { get; set; }
        public DateTime Timestamp { get; set; }
        public string WinningUserName { get; set; }
        public int? MatchUsersNumbersId { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<MatchUsersNumbers> MatchUsersNumbers { get; set; }
        
    }
}
