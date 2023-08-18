using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace AluraEstacionamento.Testes
{
    // Padr�o AAA
    // Arrange
    // Act
    // Assert
    public class VeiculoTestes
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            var veiculo = new Veiculo(); // Arrange - Inicia o ambiente/cen�rio
            veiculo.Acelerar(100); // Act - Uso do m�todo
            Assert.Equal(1000, veiculo.VelocidadeAtual); // Assert - Valida��o
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            var veiculo = new Veiculo(); // Arrange - Inicia o ambiente/cen�rio
            veiculo.Frear(10); // Act - Uso do m�todo
            Assert.Equal(-150, veiculo.VelocidadeAtual); // Assert - Valida��o
        }
        [Fact]
        public void TestaTipoVeiculo()
        {
            var veiculo = new Veiculo();
            
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);

        }

    }
}
