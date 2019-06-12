using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SBU_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Data.DbConfig
{
    public class MonsterConfiguration : IEntityTypeConfiguration<Monster>
    {
        public void Configure(EntityTypeBuilder<Monster> builder)
        {
            builder.ToTable("monster");
            builder.Property(m => m.Speed).HasConversion(v => JsonConvert.SerializeObject(v),v => JsonConvert.DeserializeObject<Dictionary<String, int>>(v)  );
            builder.Property(m => m.Skills).HasConversion(v => JsonConvert.SerializeObject(v),v => JsonConvert.DeserializeObject<Dictionary<String, int>>(v)  );
            builder.Property(m => m.Languages).HasConversion(v => JsonConvert.SerializeObject(v),v => JsonConvert.DeserializeObject<List<String>>(v)  );
            builder.Property(m => m.Tags).HasConversion(v => JsonConvert.SerializeObject(v),v => JsonConvert.DeserializeObject<List<String>>(v)  );
            builder.Property(m => m.Resistances).HasConversion(v => JsonConvert.SerializeObject(v),v => JsonConvert.DeserializeObject<List<String>>(v)  );
            builder.Property(m => m.Immunities).HasConversion(v => JsonConvert.SerializeObject(v),v => JsonConvert.DeserializeObject<List<String>>(v)  );
            builder.Property(m => m.ConditionImmunities).HasConversion(v => JsonConvert.SerializeObject(v),v => JsonConvert.DeserializeObject<List<String>>(v)  );
            builder.Property(m => m.Vulnerabilities).HasConversion(v => JsonConvert.SerializeObject(v),v => JsonConvert.DeserializeObject<List<String>>(v)  );
            
        }
    }
}
