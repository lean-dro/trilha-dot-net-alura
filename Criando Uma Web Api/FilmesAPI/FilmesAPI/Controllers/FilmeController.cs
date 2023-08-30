using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
    public IActionResult RecuperaFilmes([FromQuery]int skip = 0, int take = 50)
    {
        var query = (
            from filme
                    in _context.Filmes join genero in _context.Generos
                    on filme.Genero.Nome equals genero.Nome
            let gênero = genero.Nome
            orderby filme.Id
            select new { filme.Id, filme.Titulo, filme.Duracao, gênero}).ToList();
        
        return Ok(query);
         
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var query = (from filme
                    in _context.Filmes
                     join genero in _context.Generos
                     on filme.Genero.Nome equals genero.Nome
                     let gênero = genero.Nome
                     where filme.Id.Equals(id)
                     select new { filme.Id, filme.Titulo, filme.Duracao, gênero}).FirstOrDefault();
        if (query == null) return NotFound();
        return Ok(query);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id.Equals(id));
        if (filme == null) return NotFound("Filme não encontrado");
        var genero = _context.Generos.FirstOrDefault(generos => filmeDTO.Genero.Equals(generos.Nome));
        if (genero == null)
        {
            return NotFound("Gênero não cadastrado");
        }
        else
        {
            filme.Titulo = filmeDTO.Titulo;
            filme.Genero = genero;
            filme.Duracao = filmeDTO.Duracao;
            
            _context.SaveChanges();
            return NoContent();
        }
    }

}