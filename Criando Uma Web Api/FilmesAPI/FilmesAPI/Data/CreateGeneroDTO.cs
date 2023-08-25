using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data
{
    public class CreateGeneroDTO
    {
        [Required]
        public string Nome { get; set; }
    }
}
