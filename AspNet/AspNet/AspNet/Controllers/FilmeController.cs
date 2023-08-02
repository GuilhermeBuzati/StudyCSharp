using AspNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        //FromBody = ResquestBody(Spring Boot) -> The content will be sending by body of request (JSON)
        [HttpPost]
        public void AdicionarFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Genero);
            Console.WriteLine(filme.Duracao);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return filmes;
        }

        [HttpGet("{id}")]
        public Filme? RecuperaFilmePorId(int id)
        {
            return filmes.FirstOrDefault(filme => filme.Id == id);

        }
    }
}
