using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STSys.Core.Domain.Interfaces.EntityMapper;
using STSys.Core.Product.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Product.Abstractions.Mapping
{
    public class ProductItemEFMapping : IEntityTypeConfiguration<ProductItemEntities>, IEntityMapper
    {
        public void Configure(EntityTypeBuilder<ProductItemEntities> builder)
        {
            builder.ToTable("ProductItem").HasKey(s => s.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.HasOne(c => c.productEntities).WithMany().HasForeignKey(c => c.ProductId);
        }

        public void RegistTo(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
