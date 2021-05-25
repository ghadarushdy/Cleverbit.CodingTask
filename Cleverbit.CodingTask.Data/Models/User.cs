using System.Collections.Generic;

namespace Cleverbit.CodingTask.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? MatchUsersNumbersId { get; set; }
        public virtual ICollection<MatchUsersNumbers> MatchUsersNumbers { get; set; }
    }
}
