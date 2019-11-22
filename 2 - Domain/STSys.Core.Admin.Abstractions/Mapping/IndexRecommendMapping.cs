using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STSys.Core.Admin.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Mapping
{
    public class IndexRecommendMapping : IEntityTypeConfiguration<IndexRecommendEntity>
    {
        public void Configure(EntityTypeBuilder<IndexRecommendEntity> builder)
        {
            builder.ToTable("Recommend").HasKey(s => s.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
        }
    }
}
