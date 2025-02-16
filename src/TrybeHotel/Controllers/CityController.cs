using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
// iniciando o projeto 
namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : Controller
    {
        private readonly ICityRepository _repository;
        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult GetCities(){
            return Ok(_repository.GetCities().ToList());
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] City city){
           return Created("", _repository.AddCity(city));
        }
    }
}