using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBU_API.Dtos;
using SBU_API.Mappers;
using SBU_API.Models;

namespace SBU_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly MonsterRepository _monsterRepository;
        private readonly UserRepository _userRepository;
        private readonly MonsterMapper _monsterMapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserMapper _userMapper;

        public MonsterController(MonsterRepository monsterRepository,
                                UserRepository userRepository,
                                UserManager<IdentityUser> userManager,
                                MonsterMapper monsterMapper,
                                UserMapper userMapper)
        {
            _userMapper = userMapper;
            _userManager = userManager;
            _monsterRepository = monsterRepository;
            _userRepository = userRepository;
            _monsterMapper = monsterMapper;
        }

        [HttpGet]
        public IEnumerable<MonsterDto> GetAll()
        {
            return _monsterRepository.getAll().Select(m => _monsterMapper.mapMonsterToMonsterDto(m));
        }

        [HttpGet("{id}")]
        public ActionResult<MonsterDto> GetMonster(int id)
        {
            Monster monster = _monsterRepository.GetById(id);
            if (monster != null)
            {
                return _monsterMapper.mapMonsterToMonsterDto(monster);
            }
            else
            {
                return new MonsterDto();
            }
        }



        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public ActionResult<MonsterDto> PostMonster(MonsterDto monsterDto)
        {

            Monster monster = _monsterMapper.mapMonsterDtoToMonster(monsterDto);
            _monsterRepository.Add(monster);
            _monsterRepository.SaveChanges();
            User author = monster.Author;
            author.addToCollection(monster);
            _userRepository.Update(author);
            _userRepository.SaveChanges();

            return _monsterMapper.mapMonsterToMonsterDto(monster);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public void PutMonster(int id, MonsterDto monsterDto)
        {

            Monster monster = _monsterMapper.mapMonsterDtoToMonster(monsterDto);

            _monsterRepository.Update(monster);
            _monsterRepository.SaveChanges();

        }

        


    }
}