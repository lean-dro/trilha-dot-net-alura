using System.ComponentModel.DataAnnotations;

namespace ApiComIdentity.Data.Dtos
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string Username{ get; set; }

        [Required]
        public DateTime DataNasc { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword{ get; set; }
    }
}