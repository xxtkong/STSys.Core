using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Domain.Catalog.Entities
{
    public class ProductImages : ValueObject<ProductImages>
    {

        public string Url { get; set; }
        public string Describe { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }

        protected override bool EqualsCore(ProductImages other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
