using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NA.Covid19.Data.Interfaces;
using NA.Covid19.Domain.ApiEntities;

namespace NA.Covid19.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IDetailRepository _detailRepository;

        public DetailController(IDetailRepository detailRepository)
        {
            _detailRepository = detailRepository;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetCountries()
        {
            try
            {
                List<Country> result = await _detailRepository.GetCountries();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving countries from database");
            }
        }
    }
}