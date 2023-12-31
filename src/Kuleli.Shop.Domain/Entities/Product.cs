﻿using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string ProductDetail { get; set; }

        public int UnitInStock { get; set; }

        public decimal UnitPrice { get; set; }
     

        // Navigation Property uyguladım..!

        public Category Category { get; set; }
        
        public ICollection<ProductImage> ProductImages { get; set; }

        // Bir urunun birden fazla alicisi olabilir..!!
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public ICollection<ProductComment> ProductComments { get; set; }

    }
}
