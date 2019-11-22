using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STSys.Core.Admin.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Mapping
{
    class ModuleElementMapping : IEntityTypeConfiguration<ModuleElementEntity>
    {
        public void Configure(EntityTypeBuilder<ModuleElementEntity> builder)
        {
            builder.ToTable("ModuleElement").HasKey(s => s.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}
