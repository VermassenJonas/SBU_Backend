using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Dtos
{
    public class MonsterDto
    {
        public MonsterDto()
        {
            Languages = new List<string>();
            Tags = new List<string>();
            Resistances = new List<string>();
            Immunities = new List<string>();
            ConditionImmunities = new List<string>();
            Vulnerabilities = new List<string>();
            Traits = new List<TraitDto>();
            Actions = new List<ActionDto>();
            Speed = new Dictionary<string, int>();
            Skills = new Dictionary<string, int>();
            Stats = new StatlineDto();
            Author = new UserDto();
        }
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
        public StatlineDto Stats { get; set; }
        public List<String> Resistances { get; set; }
        public List<String> Immunities { get; set; }
        public List<String> ConditionImmunities { get; set; }
        public List<String> Vulnerabilities { get; set; }
        public Dictionary<String, int> Skills { get; set; }
        public String ChallengeRating { get; set; }
        public List<TraitDto> Traits { get; set; }
        public List<ActionDto> Actions { get; set; }
        public int LegendaryAmount { get; set; }
        public String Fluff { get; set; }
        public UserDto Author { get; set; }
        public DateTime Created { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
