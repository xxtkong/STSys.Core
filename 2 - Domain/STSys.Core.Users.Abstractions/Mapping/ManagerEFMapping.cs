﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Users.Abstractions.Mapping
{
    public class ManagerEFMapping : IEntityTypeConfiguration<ManagerEntities>
    {
        public void Configure(EntityTypeBuilder<ManagerEntities> builder)
        {
            builder.ToTable("Manager").HasKey(s=>s.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}
