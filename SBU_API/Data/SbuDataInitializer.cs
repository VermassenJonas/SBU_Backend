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
        private readonly MonsterMapper _monsterMapper;

        public SbuDataInitializer( SbuDbContext dbContext, MonsterRepository monsterRepository, MonsterMapper monsterMapper)
        {
            _dbContext = dbContext;
            _monsterRepository = monsterRepository;
            _monsterMapper = monsterMapper;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                MonsterDto monster = new MonsterDto();
                StatlineDto statline = new StatlineDto();
                statline.STR = 10;
                statline.DEX = 10;
                statline.CON = 10;
                statline.INT = 10;
                statline.WIS = 10;
                statline.CHA = 10;
                monster.Stats = statline;
                UserDto user = new UserDto();
                user.Name = "jonas";
                user.Collection.Add(monster);
                user.Email = "jonas.vermassen@fake-email.com";
                user.JoinDate = DateTime.Now;
                monster.Author = user;

                
                monster.Name = "goblin archer";
                _monsterRepository.Add(_monsterMapper.mapMonsterDtoToMonster(monster));
                _monsterRepository.SaveChanges();

            }
        }

    }

}
