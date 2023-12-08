using Business.Abstract;
using Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        IPlanetService _planetService;

        public PlanetsController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        //Add
        [HttpPost("add")]
        public IActionResult Add(PlanetDTO planetDTO)
        {
            var result= _planetService.Add(planetDTO);
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
            var result = _planetService.Delete(id);
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
            var result = _planetService.GetAll();
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
            var result = _planetService.GetById(id);
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
            var result = _planetService.Filter(temperature);
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
            var result = _planetService.Pagination(pageNo,size);
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
            var result = _planetService.SortByNameAsc();
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
            var result = _planetService.SortByNameDesc();
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
        public IActionResult Update(PlanetDTO planetDTO)
        {
            var result = _planetService.Update(planetDTO);
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
