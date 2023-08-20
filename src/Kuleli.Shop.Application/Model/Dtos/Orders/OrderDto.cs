using Kuleli.Shop.Application.Model.Dtos.OrderDetails;
using Kuleli.Shop.Domain.Entities;

namespace Kuleli.Shop.Application.Model.Dtos.Orders
{
    public class OrderDto
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public DateTime? OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderDetailsDto> OrderDetails { get; set; }
    }
}
