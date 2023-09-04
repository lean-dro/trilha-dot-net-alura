using System.ComponentModel.DataAnnotations;

namespace ApiComIdentity.Data.Dtos
{
    public class LoginUsuarioDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
