using STSys.Core.Domain.Specifications;
using STSys.Core.Product.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Product.Abstractions.Specifications
{
    public class ProductItemSpecification : BaseSpecification<ProductEntities>
    {
        public ProductItemSpecification(Guid productId) : base(b => b.Id == productId)
        {
            AddInclude(b => b.Items);
        }
    }
}
