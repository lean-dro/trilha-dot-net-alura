using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class FilmeController
{
    private static List<Filme> filmes = new List<Filme>();
    [HttpPost]
    public void AdicionaFilme([FromBody]Filme filme)
    {
    
            filmes.Add(filme);
            Console.WriteLine(filme);
      

    }
}
