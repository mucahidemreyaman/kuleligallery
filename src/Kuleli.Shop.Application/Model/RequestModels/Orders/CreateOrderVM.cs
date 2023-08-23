namespace Kuleli.Shop.Application.Model.RequestModels.Orders
{
    public class CreateOrderVM
    {
        public int? CustomerId { get; set; }
        public int? AddressId { get; set; }
    }
}
