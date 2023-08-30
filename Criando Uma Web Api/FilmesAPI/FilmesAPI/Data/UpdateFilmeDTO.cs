using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data
{
    public class UpdateFilmeDTO
    {
        [Required(ErrorMessage = "Necessário título")]
        public string Titulo { get; set; }


        [Required]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Necessário duração")]
        [Range(70, 330, ErrorMessage = "Duração inválida")]
        public int Duracao { get; set; }
    }
}
