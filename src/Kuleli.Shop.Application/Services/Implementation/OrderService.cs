using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kuleli.Shop.Application.Behaviors;
using Kuleli.Shop.Application.Exceptions;
using Kuleli.Shop.Application.Model.Dtos.Orders;
using Kuleli.Shop.Application.Model.RequestModels.Orders;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Application.Validators.Orders;
using Kuleli.Shop.Application.Wrapper;
using Kuleli.Shop.Domain.Entities;
using Kuleli.Shop.Domain.UWork;
using Microsoft.EntityFrameworkCore;

namespace Kuleli.Shop.Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitwork _uWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitwork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }


        [ValidationBehavior(typeof(GetOrdersByCustomerVM))]
        public async Task<Result<List<OrderDto>>> GetOrdersByCustomer(GetOrdersByCustomerVM getOrdersByCustomerVM)
        {
            var result = new Result<List<OrderDto>>();

            var orders = await _uWork.GetRepository<Order>().GetByFilterAsync(x => x.CustomerId == getOrdersByCustomerVM.CustomerId);
            var orderDtos = await orders.ProjectTo<OrderDto>(_mapper.ConfigurationProvider).ToListAsync();

            result.Data = orderDtos;
            return result;
        }

        [ValidationBehavior(typeof(CreateOrderValidator))]
        public async Task<Result<int>> CreateOrder(CreateOrderVM createOrderVM)
        {
            var result = new Result<int>();

            var customerExists = await _uWork.GetRepository<Customer>().AnyAsync(x => x.Id == createOrderVM.CustomerId);
            if (!customerExists)
            {
                throw new NotFoundException($"{createOrderVM.CustomerId} numaralı müşteri bulunamadı.");
            }

            var addressExists = await _uWork.GetRepository<Address>().AnyAsync(x => x.Id == createOrderVM.AddressId);
            if (!addressExists)
            {
                throw new NotFoundException($"{createOrderVM.AddressId} numaralı adres bulunamadı.");
            }

            var orderEntity = _mapper.Map<Order>(createOrderVM);
            _uWork.GetRepository<Order>().Add(orderEntity);
            await _uWork.CommitAsync();

            result.Data = orderEntity.Id;
            return result;
        }

        [ValidationBehavior(typeof(UpdateOrderValidator))]
        public async Task<Result<int>> UpdateOrder(UpdateOrderVM updateOrderVM)
        {
            var result = new Result<int>();

            var orderExists = await _uWork.GetRepository<Order>().AnyAsync(x => x.Id == updateOrderVM.OrderId);
            if (!orderExists)
            {
                throw new NotFoundException($"{updateOrderVM.OrderId} numaralı sipariş bulunamadı.");
            }

            var addressExists = await _uWork.GetRepository<Address>().AnyAsync(x => x.Id == updateOrderVM.AddressId);
            if (!addressExists)
            {
                throw new NotFoundException($"{updateOrderVM.AddressId} numaralı adres bulunamadı.");
            }

            var orderEntity = await _uWork.GetRepository<Order>().GetById(updateOrderVM.OrderId.Value);

            _mapper.Map(updateOrderVM, orderEntity);
            _uWork.GetRepository<Order>().Update(orderEntity);
            await _uWork.CommitAsync();

            result.Data = orderEntity.Id;
            return result;
        }

        [ValidationBehavior(typeof(DeleteOrderValidator))]
        public async Task<Result<int>> DeleteOrder(DeleteOrderVM deleteOrderVM)
        {
            var result = new Result<int>();

            var orderEntity = await _uWork.GetRepository<Order>().GetById(deleteOrderVM.OrderId);
            if (orderEntity is null)
            {
                throw new NotFoundException($"{deleteOrderVM.OrderId} numaralı sipariş bulunamadı.");
            }

            //Önce bu siparişe bağlı sipariş detayları bunları silelim.
            var orderDetailByOrder = await _uWork.GetRepository<OrderDetail>().GetByFilterAsync(x => x.OrderId == deleteOrderVM.OrderId);
            if (orderDetailByOrder.Any())
            {
                await orderDetailByOrder.ForEachAsync(orderDetail =>
                {
                    _uWork.GetRepository<OrderDetail>().Delete(orderDetail);
                });
            }

            //Siparişi silelim
            _uWork.GetRepository<Order>().Delete(orderEntity);
            await _uWork.CommitAsync();

            result.Data = orderEntity.Id;
            return result;
        }
    }
}

