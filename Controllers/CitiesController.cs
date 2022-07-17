using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.API.Data;
using Shipping.API.Extensions;
using Shipping.API.Models.DTOs;
using Shipping.API.Models.Entities;
using Shipping.API.Repos;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IGovernRepo repo;

        public CitiesController(IGovernRepo governRepo)
        {
            repo = governRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<City>>> GetCities()
        {
            var cities = await repo.GetCities();
            if (cities == null)
                return NoContent();

            return Ok(cities);
        }

        // GET: api/Cities/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            var city = await repo.GetCityById(id);
            if (city == null)
                return NotFound();

            var govern = await repo.GetGovernById(city.Gov_Id);
            if (govern != null)
            {

                city.Governorate = govern;
                city.ConvertToDto();
                return Ok(city);
            }
            return NotFound();
        }

        [HttpGet("{Name:alpha}")]
        public async Task<ActionResult<City>> GetCityByName([FromRoute] string name)
        {

            var city = await repo.GetCityByName(name);
            if (city == null)
                return NotFound();

            return Ok(city);
        }

        // PUT: api/Cities/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CityDto>> PutCity([FromRoute] int id, [FromBody] CityDto city)
        {
            try
            {
                var updatedCity = await repo.UpdateCity(id, city);
                if (updatedCity == null)
                    return NoContent();

                var cityDto = updatedCity.ConvertToDto();
                return CreatedAtAction(nameof(GetCities), new { id = updatedCity.Id, cityDto });
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong!");
            }
        }

        // POST: api/Cities
        [HttpPost]
        //[Route("{govId}/PostCity")]
        public async Task<ActionResult<CityDto>> PostCity([FromBody] CityDto city)
        {
            try
            {
                var newCity = await repo.AddCity(city);
                if (newCity == null)
                    return NoContent();

                var cityDto = newCity.ConvertToDto();
                return CreatedAtAction(nameof(GetCities), new { id = newCity.Id, cityDto });
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong!");
            }
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CityDto>> DeleteCity(int id)
        {
            try
            {
                var city = await repo.DeleteCity(id);
                if (city == null)
                    return Ok("Deleted Successfuly..");

                var governDto = city.ConvertToDto();
                return Ok(governDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong!");
            }
        }


    }
}
