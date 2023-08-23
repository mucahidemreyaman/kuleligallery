using AutoMapper;
using Kuleli.Shop.Application.Model.RequestModels.Accounts;
using Kuleli.Shop.Application.Model.RequestModels;
using Kuleli.Shop.Application.Model.RequestModels.Cities;

using Kuleli.Shop.Application.Model.RequestModels.Orders;
using Kuleli.Shop.Application.Model.RequestModels.OrderDetails;

using Kuleli.Shop.Application.Model.RequestModels.ProductImages;
using Kuleli.Shop.Application.Model.RequestModels.Products;
using Kuleli.Shop.Domain.Entities;

namespace Kuleli.Shop.Application.AutoMappings
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain() 
        {

            //Kaynak ve hedef arasında property isimleri veya türleri eşleşmezse manuel tanımlama yapmak gerekir.
            CreateMap<CreateCategoryViewModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.CategoryName));

            CreateMap<UpdateCategoryVievModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.CategoryName));

            //Kullanıcı oluşturma isteği
            CreateMap<RegisterVM, Customer>();
            CreateMap<RegisterVM, Account>()
                .ForMember(x => x.Role, y => y.MapFrom(e => Roles.User));

            CreateMap<UpdateUserVM, Customer>();

            //City
            CreateMap<CreateCityVM, City>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.Name.ToUpper()));
            CreateMap<UpdateCityVM, City>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.Name.ToUpper()));

            //Product
            CreateMap<CreateProductVM, Product>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.Name.Trim()));
            CreateMap<UpdateProductVM, Product>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.Name.Trim()));

            //ProductImage
            CreateMap<CreateProductImageVM, ProductImage>();

            //Order
            CreateMap<CreateOrderVM, Order>();
            CreateMap<UpdateOrderVM, Order>();

            //OrderDetail
            CreateMap<CreateOrderDetailVM, OrderDetail>();



        }
    }
}
