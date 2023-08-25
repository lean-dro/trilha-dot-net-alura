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
        public DbSet<Genero> Generos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Filme>(entidade =>
        //    {
        //        entidade.ToTable("filme");
        //        entidade.HasKey(e => e.Id);
        //        entidade.Property(e => e.Titulo);
        //        entidade.Property(e => e.Duracao);
        //        entidade.HasOne(g => g.Genero);

                
        //    });
        //    base.OnModelCreating(modelBuilder);

        //}
    }
}
