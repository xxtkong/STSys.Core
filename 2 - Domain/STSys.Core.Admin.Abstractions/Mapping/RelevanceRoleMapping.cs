using Microsoft.EntityFrameworkCore;
using STSys.Core.Admin.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Mapping
{
    public class RelevanceRoleMapping : IEntityTypeConfiguration<RelevanceRoleEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RelevanceRoleEntity> builder)
        {
            builder.ToTable("RelevanceRole").HasKey(s => s.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}
