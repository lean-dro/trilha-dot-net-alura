using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Util;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private IMapper _mapper;
        private FilmeContext _context;

        public EnderecoController(IMapper mapper, FilmeContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDTO> RecuperarEnderecos()
        {
            return _mapper.Map<List<ReadEnderecoDTO>>(_context.Enderecos).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            Endereco enderecoDesejado = _context.Enderecos.FirstOrDefault(endereco=>endereco.Id.Equals(id));
            if (enderecoDesejado == null) return NotFound("Não encontrado");
            var enderecoDTO = _mapper.Map<ReadEnderecoDTO>(enderecoDesejado);
            return Ok(enderecoDTO);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Endereco enderecoDesejado = _context.Enderecos.FirstOrDefault(endereco => endereco.Id.Equals(id));
            if (enderecoDesejado == null) return NotFound("Não encontrado");
            _context.Remove(enderecoDesejado);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDTO createEnderecoDTO)
        {

           
            ViaCep cep = new ViaCep();
            ReadEnderecoCepDTO enderecoViaApi = cep.BuscarEnderecoPeloCep(createEnderecoDTO.Cep).Result;

            Endereco endereco = new Endereco();

            _mapper.Map(createEnderecoDTO,endereco);
            _mapper.Map(enderecoViaApi,endereco);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { id = endereco.Id}, endereco);
        }

        [HttpPut("{id}")]
        public IActionResult AlterarEndereco(int id, [FromBody] UpdateEnderecoDTO updateEnderecoDTO)
        {
            Endereco enderecoDesejado = _context.Enderecos.FirstOrDefault(endereco => endereco.Id.Equals(id));
            if (enderecoDesejado == null) return NotFound("Não encontrado");
            _mapper.Map(updateEnderecoDTO, enderecoDesejado);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
