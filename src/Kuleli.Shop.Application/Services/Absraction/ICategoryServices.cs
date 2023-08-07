using Kuleli.Shop.Application.Model.Dtos;
using Kuleli.Shop.Application.Model.RequestModels;

namespace Kuleli.Shop.Application.Services.Absraction
{
    public interface ICategoryServices
    {
        //Dto Servisin Disariya gönderdigi turler
        //VM= ViewModel demektir. Servisin disaridan aldigi parametlerdir.

        #region Select 
        //Tum kategorileri getirme islemini yapmak icin bu komutları kullanırız..

        List<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int id);

        #endregion

        #region Insert, Update, Delete

        int CreateCategory(CreateCategoryViewModel createCategoryViewModel);

        int UpdateCategory(UpdateCategoryVievModel updateCategoryVievModel);

        int DeleteCategory(int id);

        //Delete islemini yapmak icin model olusturmamiza gerek yoktur. Sadece categorynin idsi yeterli olur.!!!
        #endregion

    }
}
