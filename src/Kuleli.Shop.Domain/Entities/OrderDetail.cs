using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public class OrderDetail : AuditableEntity
    {
        public int OrderId { get; set; }

        public int ProducId { get; set; }

        public int Quantity { get; set; }

        public int? DiscountId { get; set; }

        public decimal LastPrice { get; set; }

        public Order Orders { get; set; }

        public Product Products { get; set; }


    }
}
