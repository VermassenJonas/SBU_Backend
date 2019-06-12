using Microsoft.EntityFrameworkCore;
using SBU_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Data.Repositories
{
    public class MonsterRepositoryImpl : MonsterRepository
    {
        private readonly SbuDbContext _context;
        private readonly DbSet<Monster> _monsters;


        public MonsterRepositoryImpl( SbuDbContext dbContext)
        {
            _context = dbContext;
            _monsters = dbContext.Monsters;
        }

        public void Add(Monster monster)
        {
            _monsters.Add(monster);
        }

        public void Delete(Monster monster)
        {
            _monsters.Remove(monster);
        }

        public IEnumerable<Monster> getAll()
        {
            return _monsters.Include(m => m.Actions).Include(m => m.Stats).Include(m => m.Traits).Include(m => m.Author);
        }

        public Monster GetById(int id)
        {
            return _monsters.Include(m => m.Actions).Include(m => m.Stats).Include(m => m.Traits).Include(m => m.Author).SingleOrDefault(m => m.Id==id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Monster monster)
        {
            _monsters.Update(monster);
        }
    }
}
