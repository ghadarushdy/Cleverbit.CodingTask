using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cleverbit.CodingTask.Data
{
    public class MatchUsersNumbers
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public int RandomNumber { get; set; }
        public virtual User User  { get; set; }
        public virtual Match Match { get; set; }
    }
}
