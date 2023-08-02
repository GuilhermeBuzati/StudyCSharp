﻿using System.ComponentModel.DataAnnotations;

namespace AspNet.Models
{
    public class Filme
    {
        [Required(ErrorMessage = "O título do filme é obrigatório")]        
        public String Titulo { get; set; } = null!; //Null Forgive
        
        [Required(ErrorMessage = "O Gênero do filme é obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
        public String Genero { get; set; }

        [Required(ErrorMessage = "O título do Duracao é obrigatório")]
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
