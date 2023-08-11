using System.ComponentModel.DataAnnotations;

namespace AspNet.Data.Dtos
{
    public class ReadFilmeDto
    {
        public String Titulo { get; set; } = null!;

        public String Genero { get; set; }

        public int Duracao { get; set; }

        public DateTime HoraConsulta { get; set; } = DateTime.Now;
    }
}
