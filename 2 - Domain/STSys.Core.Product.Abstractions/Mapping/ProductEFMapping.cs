using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STSys.Core.Domain.Interfaces.EntityMapper;
using STSys.Core.Product.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Product.Abstractions.Mapping
{
    public class ProductEFMapping : IEntityTypeConfiguration<ProductEntities>, IEntityMapper
    {
        public void Configure(EntityTypeBuilder<ProductEntities> builder)
        {
            builder.ToTable("Product").HasKey(s => s.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.HasMany(c => c.Items).WithOne(c=>c.productEntities).HasForeignKey(c => c.ProductId);
        }

        public void RegistTo(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
