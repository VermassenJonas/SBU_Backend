using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBU_API.Dtos;
using SBU_API.Mappers;
using SBU_API.Models;

namespace SBU_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly UserMapper _userMapper;
        private readonly MonsterRepository _monsterRepository;

        public CollectionController(
                    UserRepository userRepository,
                    UserMapper userMapper,
                    MonsterRepository monsterRepository
            )
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
            _monsterRepository = monsterRepository;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{userEmail}")]
        public IEnumerable<MonsterDto> GetCollection(string userEmail)
        {
            User user = _userRepository.GetByEmail(userEmail);
            UserDto userDto = _userMapper.mapUserToUserDto(user);
            return userDto.Collection;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{userEmail}")]
        public void AddToCollection(string userEmail, MonsterDto monsterDto)
        {
            User user = _userRepository.GetByEmail(userEmail);
            Monster monster = _monsterRepository.GetById(monsterDto.Id);
            user.addToCollection(monster);
            _userRepository.Update(user);
            _userRepository.SaveChanges();

        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{userEmail}")]
        public void RemoveFromCollection(string userEmail, MonsterDto monsterDto)
        {
            User user = _userRepository.GetByEmail(userEmail);
            Monster monster = _monsterRepository.GetById(monsterDto.Id);
            user.removeFromCollection(monster);
            _userRepository.Update(user);
            _userRepository.SaveChanges();

        }
    }
}