using Business.Abstract;
using Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceWeather.Entity;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatellitesController : ControllerBase
    {
       ISatelliteService _satelliteService;

        public SatellitesController(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }

        //Adds
        [HttpPost("add")]
        public IActionResult Add(Satellite satellite)
        {
            var result = _satelliteService.Add(satellite);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //Delete
        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var result = _satelliteService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //GetAll
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _satelliteService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //GetById
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _satelliteService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //Filter
        [HttpGet("filter")]
        public IActionResult Filter([FromQuery]int temperature)
        {
            var result = _satelliteService.Filter(temperature);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //Pagination
        [HttpGet("pagination")]
        public IActionResult Pagination([FromQuery]int pageNo, [FromQuery]int size)
        {
            var result = _satelliteService.Pagination(pageNo, size);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //SortByNameAsc
        [HttpGet("sortbynameasc")]
        public IActionResult SortByNameAsc()
        {
            var result = _satelliteService.SortByNameAsc();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //SortByNameDesc
        [HttpGet("sortbynamedesc")]
        public IActionResult SortByNameDesc()
        {
            var result = _satelliteService.SortByNameDesc();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //Update
        [HttpPut("update")]
        public IActionResult Update(Satellite satellite)
        {
            var result = _satelliteService.Update(satellite);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
