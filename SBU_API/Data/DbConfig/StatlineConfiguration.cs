using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBU_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Data.DbConfig
{
    public class StatlineConfiguration : IEntityTypeConfiguration<Statline>
    {
        public void Configure(EntityTypeBuilder<Statline> builder)
        {
            builder.ToTable("statline");
        }
    }
}
