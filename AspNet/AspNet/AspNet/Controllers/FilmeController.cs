using AspNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private List<Filme> filmes = new List<Filme>();

        //FromBody = ResquestBody(Spring Boot) -> The content will be sending by body of request (JSON)
        [HttpPost]
        public void AdicionarFilme([FromBody] Filme filme)
        {
                filmes.Add(filme);
                Console.WriteLine(filme.Titulo);
                Console.WriteLine(filme.Genero);
                Console.WriteLine(filme.Duracao);
        }
    }
}
