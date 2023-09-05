using Microsoft.AspNetCore.Authorization;

public class VerificarIdade : IAuthorizationRequirement
{

   
    public VerificarIdade(int idade)
    {
        Idade = idade;
    }
    public int Idade { get; set; }
}