using KuleliGallery.Shop.UI.Models.Dtos;
using KuleliGallery.Shop.UI.Models.RequestModels;
using AutoMapper;

namespace KuleliGallery.Shop.UI.ModelMappings
{
    public class DtoToVm : Profile
    {
        public DtoToVm()
        {
            CreateMap<CategoryDto, UpdateCategoryVM>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.Name));
        }
    }
}
