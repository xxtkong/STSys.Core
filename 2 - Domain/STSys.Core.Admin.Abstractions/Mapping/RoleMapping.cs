using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STSys.Core.Admin.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Role").HasKey(s => s.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}
