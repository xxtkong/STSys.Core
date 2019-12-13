using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace STSys.Core.Product.Abstractions.Entities
{
    public class ProductItemEntities
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntities productEntities { get; set; }
    }
}
