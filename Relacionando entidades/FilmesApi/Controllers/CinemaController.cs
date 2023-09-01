using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
       
        private FilmeContext _context;
        private IMapper _mapper;
        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDTO createCinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(createCinemaDTO);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { Id = cinema.Id }, createCinemaDTO);
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDTO> RecuperarCinemas([FromQuery] int? id = null)
        {
            if (id == null)
            { 
                var listaDeCinemas = _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.ToList());
                return listaDeCinemas;
            }
            else
            {
                return  _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.
                    FromSqlInterpolated($"SELECT * FROM Cinemas WHERE Cinemas.Id = {id}").ToList());
            }
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id.Equals(id));
            if (cinema == null) return NotFound("Não Encontrado!");
            ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);
            return Ok(cinemaDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDTO updateCinemaDTO)
        {
            Cinema cinemaProcurado = _context.Cinemas.FirstOrDefault(cinema => cinema.Id.Equals(id));
            
            if(cinemaProcurado == null) return NotFound();

            _mapper.Map(updateCinemaDTO, cinemaProcurado);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinemaProcurado = _context.Cinemas.FirstOrDefault(cinema => cinema.Id.Equals(id));

            if (cinemaProcurado == null) return NotFound();
            _context.Remove(cinemaProcurado);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
