namespace Kuleli.Shop.Application.Model.RequestModels.Order
{
    public class CreateOrderVM
    {
        public int? CustomerId { get; set; }
        public int? AddressId { get; set; }
    }
}
