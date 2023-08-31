using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "Obrigatório um nome para o cinema")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
    }
}
