using Microsoft.EntityFrameworkCore;
using SBU_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Data.Repositories
{
    public class UserRepositoryImpl : UserRepository
    {
        private readonly SbuDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepositoryImpl(SbuDbContext dbContext)
        {
            _context = dbContext;
            _users = dbContext.Users;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public IEnumerable<User> getAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.Include(u => u.MonsterUsers).ThenInclude(monsterUsers => monsterUsers.Select(mu => mu.Monster)).ThenInclude(m => m.Stats).SingleOrDefault(u => u.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _users.Update(user);
        }
    }
}
