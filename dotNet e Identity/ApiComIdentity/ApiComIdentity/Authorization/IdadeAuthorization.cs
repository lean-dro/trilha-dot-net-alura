using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ApiComIdentity.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<VerificarIdade>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, VerificarIdade requirement)
        {
            Console.WriteLine(context);
            var dataNascimentoClaim = context
                            .User.FindFirst(claim =>
                            claim.Type == ClaimTypes.DateOfBirth);
            if (dataNascimentoClaim is null) return Task.CompletedTask;

            var dataNascimento = Convert.ToDateTime(dataNascimentoClaim);

            var idade = DateTime.Today.Year - dataNascimento.Year;

            if (DateTime.Today.AddYears(-idade) < dataNascimento)
            {
                idade--;
            }

            if (idade >= requirement.Idade)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
            }
        
    }
}
