using SBU_API.Dtos;
using SBU_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Mappers
{
    public class UserMapper
    {
        private readonly MonsterMapper monsterMapper;

        public UserMapper(MonsterMapper monsterMapper)
        {
            this.monsterMapper = monsterMapper;
        }
        public UserDto mapUserToUserDto(User user)
        {
            UserDto userDto = new UserDto();
            userDto.Id = user.Id;
            userDto.Name = user.Name;
            userDto.Email = user.Email;
            userDto.JoinDate = user.JoinDate;
            userDto.Collection = user.MonsterUsers.Select(mu => monsterMapper.mapMonsterToMonsterDto(mu.Monster)).ToList();
            return userDto;
        }
        public User mapUserDtoToUser(UserDto userDto)
        {
            User user = new User();
            user.Id = userDto.Id;
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.JoinDate = userDto.JoinDate;
            user.MonsterUsers = userDto.Collection.Select(m => new MonsterUser
            {
                User = user,
                UserId = userDto.Id,
                Monster = monsterMapper.mapMonsterDtoToMonster(m),
                MonsterId = m.Id
            }).ToList();
            return user;
        }
    }
}
