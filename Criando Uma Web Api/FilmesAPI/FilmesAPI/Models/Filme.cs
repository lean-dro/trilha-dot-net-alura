﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Necessário título")]
        public string Titulo { get; set; }
        
        [Required]
        public Genero Genero { get; set; }
        
        [Required(ErrorMessage = "Necessário duração")]
        [Range(70, 330, ErrorMessage ="Duração inválida")]
        public int Duracao { get; set; }

        public override string ToString()
        {
            string fichaFilme = $"Filme: {this.Titulo}\nGênero: {this.Genero.Nome}\nDuração: {this.Duracao}";
            return fichaFilme;
        }
    }
}
