using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Dtos
{
    public class UserDto
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime JoinDate { get; set; }
        public List<MonsterDto> Collection { get; set; }
    }
}
