using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController : Controller
    {
        private IMapper _mapper;
        private FilmeContext _context;
        public GeneroController(FilmeContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IEnumerable<ReadGeneroDTO> ObterTodosGeneros([FromQuery] int skip = 0, int take = 50)
        {
            return _mapper.Map<List<ReadGeneroDTO>>(_context.Generos.Skip(skip).Take(take));
        }
        [HttpGet("{id}")]
        public IActionResult ObterGeneroPorId(int id)
        {
            var generoEncontrado = _context.Generos.FirstOrDefault(generos => generos.Id == id);
            if(generoEncontrado == null)return NotFound();
            var generoDTO = _mapper.Map<ReadGeneroDTO>(generoEncontrado);
            return Ok(generoDTO);
        }
        
        [HttpPost]
        public IActionResult AdicionarGenero([FromBody] CreateGeneroDTO generoDTO)
        {
            Genero genero = _mapper.Map<Genero>(generoDTO);
            var generoEncontrado = _context.Generos.FirstOrDefault(g => g.Nome.Equals(genero.Nome));
            if (generoEncontrado == null)
            {
                _context.Generos.Add(genero);
                _context.SaveChanges();
                return CreatedAtAction(nameof(ObterGeneroPorId), new {id = genero.Id}, genero);
            }
            else
            {
                return Conflict("Já existe.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult RenomearGenero(int id, [FromBody] UpdateGenero updateGeneroDTO) 
        {
            var generoEncontrado = _context.Generos.FirstOrDefault(g => g.Id.Equals(id));
            if (generoEncontrado != null)
            {
                generoEncontrado.Nome = updateGeneroDTO.Nome;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return Conflict("Não encontrado.");
            }
           
        }
    }
}
