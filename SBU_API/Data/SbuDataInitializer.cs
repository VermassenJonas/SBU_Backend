using SBU_API.Dtos;
using SBU_API.Mappers;
using SBU_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Data
{
    public class SbuDataInitializer
    {
        private readonly SbuDbContext _dbContext;
        private readonly MonsterRepository _monsterRepository;
        private readonly UserRepository _userRepository;
        private readonly MonsterMapper _monsterMapper;

        public SbuDataInitializer( SbuDbContext dbContext, 
            MonsterRepository monsterRepository,
            UserRepository userRepository,
            MonsterMapper monsterMapper)
        {
            _dbContext = dbContext;
            _monsterRepository = monsterRepository;
            _userRepository = userRepository;
            _monsterMapper = monsterMapper;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                User u1 = new User()
                {
                    Id = 7,
                    Email = "jonas@fake.com",
                    Name = "jonas",
                    JoinDate = DateTime.Now
                };
                Monster m1 = new Monster()
                {
                    Id = 3,
                    Name = "goblin archer",
                    Size = "medium",
                    MonsterType = "humanoid",
                    Languages = new List<string>() { "common", "goblin" },
                    Tags = new List<string>() { "goblin", "sneaky" },
                    Alignment = "neutral evil",
                    ArmourClass = 14,
                    ArmourType = "leather armor",
                    Hitpoints = 11,
                    HpFormula = "2d6+4",
                    Speed = new Dictionary<string, int>()
                    {
                        {"ground", 30 }
                    },
                    Stats = new Statline()
                    {
                        STR = 10,
                        DEX = 16,
                        CON = 14,
                        INT = 8,
                        WIS = 8,
                        CHA = 10
                    },
                    Resistances = new List<string>(),
                    Immunities = new List<string>(),
                    Vulnerabilities = new List<string>(),
                    ConditionImmunities = new List<string>(),
                    Skills = new Dictionary<string, int>()
                    {
                        {"stealth" , 5 }
                    },
                    ChallengeRating = "1/4",
                    Traits = new List<Trait>()
                    {
                        new Trait()
                        {
                            Name = "Nimble Escape",
                            Description = " The goblin can take the Disengage or Hide action as a bonus action on each of its turns."
                        }
                    },
                    Actions = new List<Models.Action>()
                    {
                        new Models.Action()
                        {
                            Name = "Shortbow",
                            Type = "action",
                            Description= "Ranged Weapon Attack: +4 to hit, range 80/320 ft., one target. Hit: 5 (1d6 + 2) piercing damage."
                        }
                    },
                    Fluff = "Goblins are small, black-hearted, selfish humanoids that lair in caves, abandoned mines, despoiled dungeons, and other dismal settings. Individually weak, goblins gather in large-sometimes overwhelming-numbers. They crave power and regularly abuse whatever authority they obtain.",
                    Created = DateTime.Now
                };
                m1.LastUpdated = m1.Created;
                m1.Author = u1;
                u1.addToCollection(m1);
                Monster m2 = new Monster()
                {
                    Id = 2,
                    Name = "goblin warrior",
                    Size = "medium",
                    MonsterType = "humanoid",
                    Languages = new List<string>(){ "common", "goblin" },
                    Tags = new List<string>() { "goblin", "sneaky" },
                    Alignment = "neutral evil",
                    ArmourClass = 14,
                    ArmourType = "leather armor",
                    Hitpoints = 11,
                    HpFormula = "2d6+4",
                    Speed = new Dictionary<string, int>()
                    {
                        {"ground", 30 }
                    },
                    Stats = new Statline()
                    {
                        STR = 10,
                        DEX = 16,
                        CON = 14,
                        INT = 8,
                        WIS = 8,
                        CHA = 10
                    },
                    Resistances = new List<string>(),
                    Immunities = new List<string>() ,
                    Vulnerabilities = new List<string>() ,
                    ConditionImmunities = new List<string>() ,
                    Skills = new Dictionary<string, int>()
                    {
                        {"stealth" , 5 }
                    },
                    ChallengeRating = "1/4",
                    Traits = new List<Trait>()
                    {
                        new Trait()
                        {
                            Name = "Nimble Escape",
                            Description = " The goblin can take the Disengage or Hide action as a bonus action on each of its turns."
                        }
                    },
                    Actions = new List<Models.Action>()
                    {
                        new Models.Action()
                        {
                            Name = "Shortbow",
                            Type = "action",
                            Description= "Ranged Weapon Attack: +4 to hit, range 80/320 ft., one target. Hit: 5 (1d6 + 2) piercing damage."
                        }
                    },
                    Fluff = "Goblins are small, black-hearted, selfish humanoids that lair in caves, abandoned mines, despoiled dungeons, and other dismal settings. Individually weak, goblins gather in large-sometimes overwhelming-numbers. They crave power and regularly abuse whatever authority they obtain.",
                    Created = DateTime.Now
                };
                m2.LastUpdated = m2.Created;
                m2.Author = u1;
                u1.addToCollection(m2);
                _monsterRepository.Add(m1);
                _monsterRepository.Add(m2);
                _monsterRepository.SaveChanges();


            }
        }

    }

}
