using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data
{
    public class ReadFilmeDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }


       
        public String Genero { get; set; }
       
        public int Duracao { get; set; }


    }
}
