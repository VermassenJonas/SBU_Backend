using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Models
{
    public interface UserRepository
    {
        User GetById(int id);
        IEnumerable<User> getAll();
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        void SaveChanges();
    }
}
