using AutoMapper;
using Kuleli.Gallery.Utilies;
using Kuleli.Shop.Application.Model.RequestModels.AccountModels;
using Kuleli.Shop.Application.Model.RequestModels.CategoryModels;
using Kuleli.Shop.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Kuleli.Shop.Application.AutoMappings
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain() 
        {
            

            //kaynak ve hedef arasında property isimleri veya türleri eslesmezse manuel tanımlama yapilir.
            CreateMap<CreateCategoryViewModel, Category>()
                .ForMember(x=>x.Name, y=>y.MapFrom(e=>e.CategoryName));

            CreateMap<UpdateCategoryVievModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.CategoryName));

            //Kullanıcı olusturma istegi

            CreateMap<CreateUserVM, Customer>();
            CreateMap<CreateUserVM, Account>();
           


        }
    }
}
