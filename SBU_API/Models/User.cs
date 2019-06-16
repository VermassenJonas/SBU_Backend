using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime JoinDate { get; set; }
        public ICollection<MonsterUser> MonsterUsers { get; set; }
    }
}
