using AspNet.Data;
using AspNet.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        //FromBody = ResquestBody(Spring Boot) -> The content will be sending by body of request (JSON)
        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaFilmePorId), new {id = filme.Id}, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes([FromQuery] int skip = 0,[FromQuery] int take = 10)
        {

            return _context.Filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();

            return Ok(filme);


        }
    }
}
