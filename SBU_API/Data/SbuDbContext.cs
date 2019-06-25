using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBU_API.Data.DbConfig;
using SBU_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Data
{
    public class SbuDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<User> SbuUsers { get; set; }

        public SbuDbContext(DbContextOptions<SbuDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new MonsterConfiguration());
            builder.ApplyConfiguration(new MonsterUserConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new TraitConfiguration());
            builder.ApplyConfiguration(new ActionConfiguration());
            builder.ApplyConfiguration(new StatlineConfiguration());
        }
    }
}
