using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Logradouro { get; set; }
        public string Complemento { get; set; }

        [Range(1,10000, ErrorMessage ="Numeração ultrapassou o limite")]
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }

        [MaxLength(9, ErrorMessage = "CEP Inválido")]
        [MinLength(8, ErrorMessage = "CEP Inválido")]
        public string Cep { get; set; }
    }
}
