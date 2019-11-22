using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STSys.Core.Admin.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Mapping
{
    public class ColumnMapping : IEntityTypeConfiguration<ColumnEntity>
    {
        public void Configure(EntityTypeBuilder<ColumnEntity> builder)
        {
            builder.ToTable("Column").HasKey(s => s.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}
