using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Domain.Interfaces.EntityMapper
{
    /// <summary>
    ///继承IEntityMapper替换掉DbSet
    /// </summary>
    public interface IEntityMapper
    {
        void RegistTo(ModelBuilder modelBuilder);
    }
}
