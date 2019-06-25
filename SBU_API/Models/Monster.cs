using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Size { get; set; }
        public String MonsterType { get; set; }
        public List<String> Languages { get; set; } 
        public List<String> Tags { get; set; } 
        public String Alignment { get; set; }
        public int ArmourClass { get; set; }
        public String ArmourType { get; set; }
        public int Hitpoints { get; set; }
        public String HpFormula { get; set; }
        public Dictionary<String, int> Speed { get; set; } 
        public Statline Stats { get; set; }
        public List<String> Resistances { get; set; } 
        public List<String> Immunities { get; set; }
        public List<String> ConditionImmunities { get; set; } 
        public List<String> Vulnerabilities { get; set; } 
        public Dictionary<String, int> Skills { get; set; } 
        public String ChallengeRating { get; set; }
        public List<Trait> Traits { get; set; }
        public List<Action> Actions { get; set; }
        public String Fluff { get; set; }
        public User Author { get; set; }
        public DateTime Created { get; set; }
        public DateTime lastUpdated { get; set; }
        public ICollection<MonsterUser> MonsterUsers { get; set; }

        
    }
}
