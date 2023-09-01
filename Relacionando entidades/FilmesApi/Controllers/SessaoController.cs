using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private IMapper _mapper;
        private FilmeContext _context;
        public SessaoController(IMapper mapper, FilmeContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDTO> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadSessaoDTO>>(_context.Sessoes.ToList());
        }

        [HttpGet("{filmeId}/{cinemaId}")]
        public IActionResult RecuperaSessaoPorId(int cinemaId, int filmeId)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao=>sessao.CinemaId.Equals(cinemaId) && sessao.FilmeId.Equals(filmeId));
            if(sessao == null) return NotFound();
            ReadSessaoDTO readSessaoDTO = _mapper.Map<ReadSessaoDTO>(sessao);
            return Ok(readSessaoDTO);
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDTO createSessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(createSessaoDTO);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { cinemaId = sessao.CinemaId, filmeId = sessao.FilmeId }, sessao); 
        }

        [HttpDelete("{filmeId}/{cinemaId}")]
        public IActionResult RemoverSessao(int cinemaId, int filmeId)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.CinemaId.Equals(cinemaId) && sessao.FilmeId.Equals(filmeId));
            if (sessao == null) return NotFound();
            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
