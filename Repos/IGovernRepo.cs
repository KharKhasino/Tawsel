using Shipping.API.Models.DTOs;
using Shipping.API.Models.Entities;

namespace Shipping.API.Repos
{
    public interface IGovernRepo
    {
        Task<Governorate> AddGovern(GovernDto governorate);
        Task<Governorate> DeleteGovern(int id);
        Task<List<Governorate>> GetGoverns();
        Task<Governorate> GetGovernById(int id);
        Task<GovernCitiesDto> GetGovernDetails(int id);
        Task<City> AddCity(CityDto city);
        Task<List<City>> GetCities();
        Task<List<City>> GetCities(int id);
        Task<City> GetCityById(int id);
        Task<City> UpdateCity(int id, CityDto city);
        Task<City> DeleteCity(int id);
        Task<City> GetCityByName(string name);
    }
}
