using SBU_API.Dtos;
using SBU_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Mappers
{
    public class MonsterMapper
    {
        private readonly UserRepository _userRepository;

        public MonsterMapper(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public MonsterDto mapMonsterToMonsterDto(Monster monster)
        {
            MonsterDto monsterDto = new MonsterDto();
            monsterDto.Id = monster.Id;
            monsterDto.Name = monster.Name;
            monsterDto.Size = monster.Size;
            monsterDto.MonsterType = monster.MonsterType;
            if (monster.Languages != null) monsterDto.Languages = monster.Languages;
            if (monster.Tags != null) monsterDto.Tags = monster.Tags;
            monsterDto.Alignment = monster.Alignment;
            monsterDto.ArmourClass = monster.ArmourClass;
            monsterDto.ArmourType = monster.ArmourType;
            monsterDto.Hitpoints = monster.Hitpoints;
            monsterDto.HpFormula = monster.HpFormula;
            if (monsterDto.Speeds != null) {
                foreach (string speedName in monster.Speed.Keys)
                {
                    monsterDto.Speeds.Add(new SpeedDto() {
                        SpeedName = speedName,
                        SpeedValue = monster.Speed[speedName]
                    });
                }
            }
            if (monster.Stats != null) monsterDto.Stats = mapStatlineToStatlineDto(monster.Stats);
            if (monster.Resistances != null) monsterDto.Resistances = monster.Resistances;
            if (monster.Immunities != null) monsterDto.Immunities = monster.Immunities;
            if (monster.ConditionImmunities != null) monsterDto.ConditionImmunities = monster.ConditionImmunities;
            if (monster.Vulnerabilities != null) monsterDto.Vulnerabilities = monster.Vulnerabilities;
            if (monster.Skills != null) {
                foreach (string skillName in monster.Skills.Keys)
                {
                    monsterDto.Skills.Add(new SkillDto()
                    {
                        SkillName = skillName,
                        SkillMod = monster.Skills[skillName]
                    });
                }
            }
            monsterDto.ChallengeRating = monster.ChallengeRating;
            if (monster.Traits != null) monsterDto.Traits = monster.Traits.Select(t => mapTraitToTraitDto(t)).ToList();
            if (monster.Actions != null) monsterDto.Actions = monster.Actions.Select(a => mapActionToActionDto(a)).ToList();
            monsterDto.Fluff = monster.Fluff;
            monsterDto.Author = mapUserToUserDto(monster.Author);
            monsterDto.Created = monster.Created;
            monsterDto.lastUpdated = monster.LastUpdated;
            return monsterDto;
        }
        public Monster mapMonsterDtoToMonster(MonsterDto monsterDto)
        {
            Monster monster = new Monster();
            monster.Id = monsterDto.Id;
            monster.Name = monsterDto.Name;
            monster.Size = monsterDto.Size;
            monster.MonsterType = monsterDto.MonsterType;
            monster.Languages = monsterDto.Languages;
            monster.Tags = monsterDto.Tags;
            monster.Alignment = monsterDto.Alignment;
            monster.ArmourClass = monsterDto.ArmourClass;
            monster.ArmourType = monsterDto.ArmourType;
            monster.Hitpoints = monsterDto.Hitpoints;
            monster.HpFormula = monsterDto.HpFormula;
            monster.Speed = new Dictionary<string, int>();
            monster.Stats = mapStatlineDtoToStatline(monsterDto.Stats);
            monster.Resistances = monsterDto.Resistances;
            monster.Immunities = monsterDto.Immunities;
            monster.ConditionImmunities = monsterDto.ConditionImmunities;
            monster.Vulnerabilities = monsterDto.Vulnerabilities;
            monster.Skills = new Dictionary<string, int>();
            monster.ChallengeRating = monsterDto.ChallengeRating;
            monster.Traits = monsterDto.Traits.Select(t => mapTraitDtoToTrait(t)).ToList();
            monster.Actions = monsterDto.Actions.Select(a => mapActionDtoToAction(a)).ToList();
            monster.Fluff = monsterDto.Fluff;
            monster.Created = monsterDto.Created;
            monster.LastUpdated = monsterDto.lastUpdated;
            foreach (SpeedDto speed in monsterDto.Speeds)
            {
                monster.Speed.Add(speed.SpeedName, speed.SpeedValue);
            }
            foreach (SkillDto skill in monsterDto.Skills)
            {
                monster.Skills.Add(skill.SkillName, skill.SkillMod);
            }


            if(monsterDto.Author == null || monsterDto.Author.Email == null || monsterDto.Author.Email.Equals(""))
            {
                User author = _userRepository.GetByEmail(monsterDto.AuthorEmail);
                if(author != null)
                {
                    monster.Author = author;
                }
                else
                {
                    throw new Exception("no author present on submitted monster");
                }
            }
            else
            {
                monster.Author = mapUserDtoToUser(monsterDto.Author);
            }
            return monster;
        }

        public TraitDto mapTraitToTraitDto(Trait trait)
        {
            TraitDto traitDto = new TraitDto();
            traitDto.Description = trait.Description;
            traitDto.Name = trait.Name;
            traitDto.Id = trait.Id;
            return traitDto;
        }
        public Trait mapTraitDtoToTrait(TraitDto traitDto)
        {
            Trait trait = new Trait();
            trait.Description = traitDto.Description;
            trait.Name = traitDto.Name;
            trait.Id = traitDto.Id;
            return trait;
        }
        public StatlineDto mapStatlineToStatlineDto(Statline Statline)
        {
            StatlineDto StatlineDto = new StatlineDto();
            StatlineDto.Id = Statline.Id;
            StatlineDto.STR = Statline.STR;
            StatlineDto.DEX = Statline.DEX;
            StatlineDto.CON = Statline.CON;
            StatlineDto.INT = Statline.INT;
            StatlineDto.WIS = Statline.WIS;
            StatlineDto.CHA = Statline.CHA;
            return StatlineDto;
        }
        public Statline mapStatlineDtoToStatline(StatlineDto statlineDto)
        {
            Statline statline = new Statline();
            statline.Id = statlineDto.Id;
            statline.STR = statlineDto.STR;
            statline.DEX = statlineDto.DEX;
            statline.CON = statlineDto.CON;
            statline.INT = statlineDto.INT;
            statline.WIS = statlineDto.WIS;
            statline.CHA = statlineDto.CHA;
            return statline;
        }
        public ActionDto mapActionToActionDto(Models.Action Action)
        {
            ActionDto ActionDto = new ActionDto();
            ActionDto.Description = Action.Description;
            ActionDto.Name = Action.Name;
            ActionDto.Id = Action.Id;
            ActionDto.Type = Action.Type;
            return ActionDto;
        }
        public Models.Action mapActionDtoToAction(ActionDto ActionDto)
        {
            Models.Action Action = new Models.Action();
            Action.Description = ActionDto.Description;
            Action.Name = ActionDto.Name;
            Action.Id = ActionDto.Id;
            Action.Type = ActionDto.Type;
            return Action;
        }
        public UserDto mapUserToUserDto(User user)
        {
            UserDto userDto = new UserDto();
            userDto.Id = user.Id;
            userDto.Name = user.Name;
            userDto.Email = user.Email;
            userDto.JoinDate = user.JoinDate;
            userDto.Collection = new List<MonsterDto>();
            return userDto;
        }
        public User mapUserDtoToUser(UserDto userDto)
        {
            User user = new User();
            user.Id = userDto.Id;
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.JoinDate = userDto.JoinDate;
            user.MonsterUsers = new List<MonsterUser>();
            return user;
        }


    }
}
