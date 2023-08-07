using Kuleli.Shop.Application.Model.Dtos;
using Kuleli.Shop.Application.Model.RequestModels;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Persistance.Context;

namespace Kuleli.Shop.Application.Services.Implementation
{
    public class CategoryService : ICategoryServices
    {
        private readonly KuleliGalleryContext _context;
        public CategoryService()
        {
           
        }
        public int CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            throw new NotImplementedException();
        }

        public int DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateCategory(UpdateCategoryVievModel updateCategoryVievModel)
        {
            throw new NotImplementedException();
        }
    }
}
