using AutoMapper;
using Kuleli.Shop.Application.Model.Dtos.Accounts;
using Kuleli.Shop.Application.Model.Dtos;
using Kuleli.Shop.Application.Model.Dtos.Cities;
using Kuleli.Shop.Application.Model.Dtos.Customers;
using Kuleli.Shop.Application.Model.Dtos.OrderDetails;
using Kuleli.Shop.Application.Model.Dtos.Orders;
using Kuleli.Shop.Application.Model.Dtos.ProductImages;
using Kuleli.Shop.Application.Model.Dtos.Products;
using Kuleli.Shop.Domain.Entities;

namespace Kuleli.Shop.Application.AutoMappings
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<Account, AccountDto>();

            CreateMap<City, CityDto>();

            CreateMap<Product, ProductDto>();
           
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Product, ProductWithImagesDto>();

            CreateMap<ProductImage, ProductWithImagesDto>();
            CreateMap<ProductImage, ProductImageWithProductDto>();

            CreateMap<Order, OrderDto>();

            CreateMap<OrderDetail, OrderDetailDto>();
        }
    }
}
