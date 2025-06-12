using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService _service;

        public FilmsController(IFilmService service)
        {
            _service = service;
        }

       
        /// Pobiera wszystkie filmy
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Film>), 200)]
        public IActionResult GetAll()
        {
            var films = _service.GetAll();
            return Ok(films);
        }

      
        /// Pobiera film o wskazanym id
        
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Film), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var film = _service.GetById(id);
            if (film is null)
                return NotFound(new { Message = $"Film o id={id} nie istnieje." });
            return Ok(film);
        }

        
        /// Tworzy nowy film
       
        [HttpPost]
        [ProducesResponseType(typeof(Film), 201)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] FilmBody body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _service.Add(body);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created
            );
        }

      
        /// Aktualizuje istniejący film
       
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Update(int id, [FromBody] FilmBody body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_service.Update(id, body))
                return NotFound(new { Message = $"Film o id={id} nie istnieje." });

            return NoContent();
        }

        
        /// Usuwa film o wskazanym id
       
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound(new { Message = $"Film o id={id} nie istnieje." });

            return NoContent();
        }

    }
}
