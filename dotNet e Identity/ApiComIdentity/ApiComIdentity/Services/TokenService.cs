using ApiComIdentity.Data.Dtos;
using ApiComIdentity.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;

namespace ApiComIdentity.Services
{
    public class TokenService
    {
        public string GerarToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]{
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id)
            };
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ALEATORIO1120931401EWIYEWF973HFUP3YF98Y8983YFEI839POWFJB23984"));
            var signInCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(1),
                claims: claims,
                signingCredentials: signInCredentials
                );

           return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
