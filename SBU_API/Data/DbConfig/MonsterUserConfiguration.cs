using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBU_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Data.DbConfig
{
    public class MonsterUserConfiguration : IEntityTypeConfiguration<MonsterUser>
    {
        public void Configure(EntityTypeBuilder<MonsterUser> builder)
        {
            builder.ToTable("monster_user");
            builder.HasKey(mu => new { mu.MonsterId, mu.UserId });
            builder.HasOne(mu => mu.Monster).WithMany(m => m.MonsterUsers).HasForeignKey(mu => mu.MonsterId);
            builder.HasOne(mu => mu.User).WithMany(u => u.MonsterUsers).HasForeignKey(mu => mu.UserId);
        }
    }
}
