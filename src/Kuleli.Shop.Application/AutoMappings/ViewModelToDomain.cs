using AutoMapper;
using Kuleli.Shop.Application.Model.RequestModels;
using Kuleli.Shop.Domain.Entities;

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


        }
    }
}
