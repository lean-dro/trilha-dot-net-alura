using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatório um nome para o cinema")]
        public string Nome { get; set; }
        public int EnderecoId { get; set;}
        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
