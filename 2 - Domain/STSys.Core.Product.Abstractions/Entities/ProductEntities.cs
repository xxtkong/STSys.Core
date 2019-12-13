using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Product.Abstractions.Entities
{
    public class ProductEntities : Entity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Images { get; set; }


        private readonly List<ProductItemEntities> _items = new List<ProductItemEntities>();
        public ICollection<ProductItemEntities> Items => _items;
        public void AddItem(Guid productId, string key,string value)
        {
            _items.Add(new ProductItemEntities()
            {
                ProductId = productId,
                Key = key,
                Value = value
            });
        }

    }
}
