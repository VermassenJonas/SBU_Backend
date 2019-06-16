﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private readonly MonsterMapper _monsterMapper;

        public MonsterController(MonsterRepository monsterRepository, MonsterMapper monsterMapper)
        {
            _monsterRepository = monsterRepository;
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
            return _monsterMapper.mapMonsterToMonsterDto(_monsterRepository.GetById(id));
        }



        [HttpPost]
        public ActionResult<MonsterDto> PostMonster()
        {
            Monster monster = new Monster();
            _monsterRepository.Add(monster);
            _monsterRepository.SaveChanges();
            return _monsterMapper.mapMonsterToMonsterDto(monster);
        }

        [HttpPut("{id}")]
        public void PutMonster(int id, MonsterDto monsterDto) {
            _monsterRepository.Update(_monsterMapper.mapMonsterDtoToMonster(monsterDto));
            _monsterRepository.SaveChanges();
        }


    }
}