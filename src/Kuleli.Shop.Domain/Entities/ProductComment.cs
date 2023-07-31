using Kuleli.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Domain.Entities
{
    public class ProductComment : AuditableEntity
    {
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public string Detail { get; set; }

        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
        public bool? IsApproved { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }

    }
}
