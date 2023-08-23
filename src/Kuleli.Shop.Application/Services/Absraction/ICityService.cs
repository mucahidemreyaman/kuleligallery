using Kuleli.Shop.Application.Model.Dtos.Cities;
using Kuleli.Shop.Application.Model.RequestModels.Cities;
using Kuleli.Shop.Application.Wrapper;

namespace Kuleli.Shop.Application.Services.Absraction
{
    public interface ICityService
    {
        Task<Result<List<CityDto>>> GetAllCities();
        Task<Result<CityDto>> GetCityById(int id);

        Task<Result<int>> CreateCity(CreateCityVM createCityVM);
        Task<Result<bool>> UpdateCity(UpdateCityVM updateCityVM);
        Task<Result<bool>> DeleteCity(int id);
    }
}
