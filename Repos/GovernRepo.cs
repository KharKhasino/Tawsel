using Microsoft.EntityFrameworkCore;
using Shipping.API.Data;
using Shipping.API.Extensions;
using Shipping.API.Models.DTOs;
using Shipping.API.Models.Entities;

namespace Shipping.API.Repos
{
    public class GovernRepo : IGovernRepo
    {
        private readonly AppDbContext context;
        public GovernRepo(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Governorate>> GetGoverns()
        {
            var governs = await context.Governorates.ToListAsync();
            return governs;
        }
        public async Task<Governorate> GetGovernById(int id)
        {
            var govern = await context.Governorates.FirstOrDefaultAsync(g => g.Id == id);
            return govern;
        }
        public async Task<GovernCitiesDto> GetGovernDetails(int id)
        {
            var govern = await context.Governorates.FirstOrDefaultAsync(g => g.Id == id);
            if (govern != null)
            {

                var cities = await context.Cities.Include(c => c.Governorate).Where(c => c.Gov_Id == govern.Id).ToListAsync();
                if (cities.Any())
                {
                    var details = new GovernCitiesDto
                    {
                        Id = govern.Id,
                        Name = govern.Name,
                    };

                    foreach (var item in cities)
                    {
                        details.Cities.Add(item.Name, item.Price);
                    }

                    return details;
                }
                var gov = new GovernCitiesDto
                {
                    Id = govern.Id,
                    Name = govern.Name
                };
                return gov;
            }
            return null;
        }
        public async Task<Governorate> DeleteGovern(int id)
        {
            var govern = await GetGovernById(id);
            if (govern != null)
            {
                context.Governorates.Remove(govern);
                await context.SaveChangesAsync();
            }

            return govern;

        }
        public async Task<Governorate> AddGovern(GovernDto gov)
        {
            var newGov = new Governorate
            {
                Id = new int(),
                Name = gov.Name,
            };
            await context.AddAsync(newGov);
            await context.SaveChangesAsync();
            return newGov;
        }

        public async Task<City> AddCity(CityDto city)
        {
            var govern = await context.Governorates.FirstOrDefaultAsync(g => g.Id == city.GovId);
            if (govern != null)
            {
                var newCity = new City
                {
                    Id = new int(),
                    Name = city.Name,
                    Price = city.Price,
                    Gov_Id = city.GovId,
                    Governorate = govern
                };
                await context.AddAsync(newCity);
                await context.SaveChangesAsync();
                return newCity;
            }
            return null;
        }
        public async Task<City> UpdateCity(int id, CityDto city)
        {
            var oldCity = await context.Cities.Include(c => c.Governorate).FirstOrDefaultAsync(c => c.Id == id);
            if (oldCity != null)
            {
                oldCity.Price = city.Price;
                oldCity.Name = city.Name;
                await context.SaveChangesAsync();
                return oldCity;
            }
            return null;
        }
        public async Task<City> DeleteCity(int id)
        {
            var city = await context.Cities.Include(c => c.Governorate).SingleOrDefaultAsync(c => c.Id == id); ;
            if (city != null)
            {
                context.Cities.Remove(city);
                await context.SaveChangesAsync();
            }

            return city;
        }
        public async Task<List<City>> GetCities()
        {
            var cities = await (from city in context.Cities
                                join govern in context.Governorates on city.Gov_Id equals govern.Id
                                select new City
                                {
                                    Id = city.Id,
                                    Name = city.Name,
                                    Price = city.Price,
                                    Gov_Id = city.Gov_Id,
                                    Governorate = govern,
                                }).ToListAsync();
            return cities;
        }
        public async Task<List<City>> GetCities(int id)
        {
            var cities = await context.Cities.Include(c => c.Governorate).Where(c => c.Gov_Id == id).ToListAsync();
            return cities;
        }

        public Task<City> GetCityById(int id)
        {
            var city = context.Cities.FirstOrDefaultAsync(c => c.Id == id);
            return city;
        }
        public Task<City> GetCityByName(string name)
        {
            var city = context.Cities.FirstOrDefaultAsync(c => c.Name.Replace(" ","") == name);
            return city;
        }
    }
}
