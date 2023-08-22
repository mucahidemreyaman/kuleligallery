using Kuleli.Shop.Application.Model.Dtos.CategoryDtos;
using Kuleli.Shop.Application.Model.RequestModels.CategoryModels;
using Kuleli.Shop.Application.Wrapper;

namespace Kuleli.Shop.Application.Services.Absraction
{
    public interface ICategoryService
    {
        //Dto Servisin Disariya gönderdigi turler
        //VM= ViewModel demektir. Servisin disaridan aldigi parametlerdir.

        #region Select 
        //Tum kategorileri getirme islemini yapmak icin bu komutları kullanırız..

        Task<Result<List<CategoryDto>>> GetAllCategories();
        Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdViewModel getCategoryByIdViewModel);

        #endregion

        #region Insert, Update, Delete

        Task<Result<int>> CreateCategory(CreateCategoryViewModel createCategoryViewModel);

        Task<Result<int>> UpdateCategory(UpdateCategoryVievModel updateCategoryVievModel);

        Task<Result<int>> DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel);

        //Delete islemini yapmak icin model olusturmamiza gerek yoktur. Sadece categorynin idsi yeterli olur.!!!
        #endregion

    }
}
