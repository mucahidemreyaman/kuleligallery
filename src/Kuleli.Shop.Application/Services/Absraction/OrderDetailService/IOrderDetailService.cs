using Kuleli.Shop.Application.Model.Dtos.OrderDetails;
using Kuleli.Shop.Application.Model.RequestModels.OrderDetails;
using Kuleli.Shop.Application.Wrapper;

namespace Kuleli.Shop.Application.Services.Absraction.OrderDetailService
{
    public interface IOrderDetailService
    {
        #region Select
        Task<Result<List<OrderDetailsDto>>> GetOrderDetailsByOrderId(GetOrderDetailsByOrderIdVM getByOrderIdVM);

        #endregion

        #region Insert, Update, Delete

        Task<Result<int>> CreateOrderDetail(CreateOrderDetailVM createOrderDetailVM);
        Task<Result<int>> DeleteOrderDetail(DeleteOrderDetailVM deleteOrderDetailVM);

        #endregion
    }
}
