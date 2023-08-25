using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private static List<Filme> filmes = new List<Filme>();
    private static int Identificador = 0;
   
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody]Filme filme)
    {
        filme.Identificador = Identificador++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmePorId), new {id=filme.Identificador}, filme);
       
    }
    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        
        var filme = filmes.FirstOrDefault(filme => filme.Identificador.Equals(id));
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
