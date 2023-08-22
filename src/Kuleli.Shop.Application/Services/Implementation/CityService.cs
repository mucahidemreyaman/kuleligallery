using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kuleli.Shop.Application.Exceptions;
using Kuleli.Shop.Application.Model.Dtos.CityDto;
using Kuleli.Shop.Application.Model.RequestModels.CittModels;
using Kuleli.Shop.Application.Model.RequestModels.CityModels;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Application.Wrapper;
using Kuleli.Shop.Domain.Entities;
using Kuleli.Shop.Domain.UWork;
using Kuleli.Shop.Persistance.UWork;

namespace Kuleli.Shop.Application.Services.Implementation
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly IUnitwork _uwork;

        public CityService(IMapper mapper, UnitWork uwork)
        {
            _mapper = mapper;
            _uwork = uwork;
        }

        public async Task<Result<List<CityDto>>> GetAllCities()
        {
            var result = new Result<List<CityDto>>();

            var cityEntites = await _uwork.GetRepository<City>().GetAllAsync();
            var cityDtos = cityEntites.ProjectTo<CityDto>(_mapper.ConfigurationProvider).ToList();

            result.Data = cityDtos;
            return result;
        }

        public async Task<Result<CityDto>> GetCityById(int id)
        {
            var result = new Result<CityDto>();

            var cityEntity = await _uwork.GetRepository<City>().GetById(id);

            var cityDto = _mapper.Map<CityDto>(cityEntity);

            result.Data = cityDto;
            return result;
        }

        public async Task<Result<int>> CreateCity(CreateCityVM createCityVM)
        {
            var result = new Result<int>();

            var cityNameExists = await _uwork.GetRepository<City>().AnyAsync(x => x.Name == createCityVM.Name.ToUpper().Trim());
            if (cityNameExists)
            {
                throw new AlreadyExistsException($"{createCityVM.Name} isminde bir şehir eklenmiştir.");
            }

            var cityEntity = _mapper.Map<City>(createCityVM);

            _uwork.GetRepository<City>().Add(cityEntity);
            await _uwork.CommitAsync();

            result.Data = cityEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteCity(int id)
        {
            var result = new Result<bool>();

            var cityById = await _uwork.GetRepository<City>().GetById(id);
            if (cityById is null)
            {
                throw new NotFoundException($"{id} NUMARALI SEHİR BULUNAMADI.");
            }

            _uwork.GetRepository<City>().Delete(cityById);
            result.Data = await _uwork.CommitAsync();

            return result;
        }

        public async Task<Result<bool>> UpdateCity(UpdateCityVM updateCityVM)
        {
            var result = new Result<bool>();

            var cityIdExists = await _uwork.GetRepository<City>().AnyAsync(x => x.Id == updateCityVM.Id);
            if (!cityIdExists)
            {
                throw new NotFoundException($"{updateCityVM.Id} NUMARALI SEHİR BULUNAMADI.");
            }

            var cityNameExists = await _uwork.GetRepository<City>().AnyAsync(x => x.Id != updateCityVM.Id && x.Name == updateCityVM.Name.ToUpper().Trim());
            if (cityNameExists)
            {
                throw new AlreadyExistsException($"{updateCityVM.Name} ISMINDE SEHIR EKLENMISTIR.");
            }

            var existsCityEntity = await _uwork.GetRepository<City>().GetById(updateCityVM.Id.Value);

            _mapper.Map(updateCityVM, existsCityEntity);

            _uwork.GetRepository<City>().Update(existsCityEntity);
            result.Data = await _uwork.CommitAsync();

            return result;
        }
    }
}
