using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public int OrderTime { get; set; }
        public DateTime OrderDate { get; set; }
             
        public OrderStatus Status { get; set; }

        public DeliveryType DeliveryType { get; set; }

        // Siparisin sadece bir müsteriye ait oldugunu belli etmek icin NP kullandım..
        public Customer Customer { get; set; }

        public Address Address { get; set; }

        // Bir musterinin birden fazla siparisi olabilir.
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
    public enum OrderStatus
    {
        OrderCreated = 1,
        PaymentComplated = 2,
        Pending = 3,
        OrderDelivering = 4,
        CargoDelivered = 5,
        Complated = 6
    }
    public enum DeliveryType
    {
        Address = 1,
        ShoppingCentre = 2
    }

}
