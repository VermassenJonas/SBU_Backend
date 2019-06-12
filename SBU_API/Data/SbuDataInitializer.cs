using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Data
{
    public class SbuDataInitializer
    {
        private readonly SbuDbContext _dbContext;

        public SbuDataInitializer( SbuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //init data
            }
        }

    }

}
