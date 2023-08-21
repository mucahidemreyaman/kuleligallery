using Kuleli.Shop.Application.Model.Dtos.CityDto;
using Kuleli.Shop.Application.Model.RequestModels.CittModels;
using Kuleli.Shop.Application.Model.RequestModels.CityModels;
using Kuleli.Shop.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Services.Absraction.CityService
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
