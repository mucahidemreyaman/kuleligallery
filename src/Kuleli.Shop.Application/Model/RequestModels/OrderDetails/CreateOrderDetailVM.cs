namespace Kuleli.Shop.Application.Model.RequestModels.OrderDetails
{
    public class CreateOrderDetailVM
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
