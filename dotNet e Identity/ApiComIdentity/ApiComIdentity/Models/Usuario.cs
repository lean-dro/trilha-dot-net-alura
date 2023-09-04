using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApiComIdentity.Models
{
    public class Usuario : IdentityUser
    {
        public Usuario() : base()
        {   
            
        }
        [Required]
        public DateTime DataNasc { get; set; }
    }
}