using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Models
{
    public interface MonsterRepository
    {
        Monster GetById(int id);
        IEnumerable<Monster> getAll();
        void Add(Monster monster);
        void Delete(Monster monster);
        void Update(Monster monster);
        void SaveChanges();
    }
}
