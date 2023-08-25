using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private FilmeContext _context;
    private IMapper _mapper;
    public FilmeController(FilmeContext contexto, IMapper mapper)
    {
        _mapper = mapper;
        _context = contexto;

    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody]CreateFilmeDTO filmeDTO)
    {
        var genero = _context.Generos.FirstOrDefault(generos => filmeDTO.Genero.Equals(generos.Nome));
        if (genero == null)
        {
            return NotFound("Gênero não cadastrado");
        }
        else
        {
            var filme = new Filme()
            {
                Titulo = filmeDTO.Titulo,
                Genero = genero,
                Duracao = filmeDTO.Duracao,
            };
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new {id=filme.Id}, filme);
        }
       
    }
    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, int take = 50)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id.Equals(id));
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
