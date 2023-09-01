using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FilmesApi.Data.Dtos
{
    public class CreateSessaoDTO
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
    }
}
