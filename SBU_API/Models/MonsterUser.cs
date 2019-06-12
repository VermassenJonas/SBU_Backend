using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Models
{
    public class MonsterUser
    {
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
