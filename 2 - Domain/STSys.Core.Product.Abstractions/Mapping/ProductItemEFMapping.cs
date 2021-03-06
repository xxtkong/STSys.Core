﻿using Microsoft.EntityFrameworkCore;
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
            builder.HasOne(c => c.productEntities).WithMany(c=>c.Items).HasForeignKey(c => c.ProductId).IsRequired(true);
        }

        public void RegistTo(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
