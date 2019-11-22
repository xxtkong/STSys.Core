using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STSys.Core.Admin.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Mapping
{
    class RelevanceElementMapping : IEntityTypeConfiguration<RelevanceElementEntity>
    {
        public void Configure(EntityTypeBuilder<RelevanceElementEntity> builder)
        {
            builder.ToTable("RelevanceElement").HasKey(s => s.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}
