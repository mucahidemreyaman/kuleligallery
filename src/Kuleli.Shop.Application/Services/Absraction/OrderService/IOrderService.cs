using Kuleli.Shop.Application.Model.Dtos.Orders;
using Kuleli.Shop.Application.Model.RequestModels.Order;
using Kuleli.Shop.Application.Model.RequestModels.Orders;
using Kuleli.Shop.Application.Wrapper;

namespace Kuleli.Shop.Application.Services.Absraction.OrderService
{
    public interface IOrderService
    {
        #region Select
        Task<Result<List<OrderDto>>> GetOrdersByCustomer(GetOrdersByCustomerVM getOrderByCustomerVM);

        #endregion

        #region Insert, Update, Delete
        Task<Result<int>> CreateOrder(CreateOrderVM createOrderVM);
        Task<Result<int>> UpdateOrder(UpdateOrderVM updateOrderVM);
        Task<Result<int>> DeleteOrder(DeleteOrderVM deleteOrderVM);
        #endregion
    }
}
