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
    public class GovernoratesController : ControllerBase
    {
        private readonly IGovernRepo repo;

        public GovernoratesController(IGovernRepo governRepo)
        {
            repo = governRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<GovernDto>>> GetGovernorates()
        {
            var governorates = await repo.GetGoverns();
            var governs = governorates.ConvertToDto();
            return Ok(governs);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GovernCitiesDto>> GetGovernorate(int id)
        {

            var governDetails = await repo.GetGovernDetails(id);

            return Ok(governDetails);
        }

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> PutGovernorate(int id, Governorate governorate)
        //{
        //    if (id != governorate.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(governorate).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GovernorateExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<GovernDto>> PostGovernorate([FromBody] GovernDto gov)
        {
            try
            {
                var result = await repo.AddGovern(gov);
                if (result == null)
                    return NotFound();

                var newGov = result.ConvertToDto;
                return CreatedAtAction(nameof(GetGovernorate),
                    new { id = result.Id }, newGov);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong!");

            }

        }

        // DELETE: api/Governorates/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GovernDto>> DeleteGovernorate(int id)
        {
            try
            {
                var gov = await repo.DeleteGovern(id);
                if (gov == null)
                    return Ok("Deleted Successfuly..");

                var governDto = gov.ConvertToDto();
                return Ok(governDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong!");
            }
        }


    }
}
