using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateEnderecoDTO
    {
        [Required]
        [MinLength(8)]
        public string Cep { get; set; }
        public int Numero { get; set; }
    }
}
