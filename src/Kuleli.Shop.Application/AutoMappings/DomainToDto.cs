using AutoMapper;
using Kuleli.Shop.Application.Model.Dtos;
using Kuleli.Shop.Domain.Entities;

namespace Kuleli.Shop.Application.AutoMappings
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
