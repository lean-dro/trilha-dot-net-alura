using FilmesAPI.Models;

namespace FilmesAPI.Testes
{
    public class TestesFilme
    {
        Filme filme;
        public TestesFilme()
        {
            filme = new Filme();
        }
        [Fact]
        public void TestaDuracaoInvalidaDoFilme()
        {
            filme.Titulo = "Teste";
            filme.Duracao = 500;
            filme.Genero.Nome = "Teste";

            Assert.True(!(filme.Duracao <= 330));
        }
        [Fact]
        public void TestaDuracaoValidaDoFilme()
        {
            filme.Titulo = "Teste";
            filme.Duracao = 329;
            filme.Genero.Nome = "Teste";

            Assert.True((filme.Duracao <= 330));
        }
    }
}