using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> option) : base(option)
        {

        }
        public DbSet<Filme> Filmes { get; set; }

    }
}
