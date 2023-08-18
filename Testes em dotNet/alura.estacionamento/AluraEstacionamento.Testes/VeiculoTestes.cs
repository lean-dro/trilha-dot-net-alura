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
        [Fact(DisplayName = "Teste de acelera��o")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            var veiculo = new Veiculo(); // Arrange - Inicia o ambiente/cen�rio
            veiculo.Acelerar(100); // Act - Uso do m�todo
            Assert.Equal(1000, veiculo.VelocidadeAtual); // Assert - Valida��o
        }

        [Fact(DisplayName ="Teste de freio")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            var veiculo = new Veiculo(); // Arrange - Inicia o ambiente/cen�rio
            veiculo.Frear(10); // Act - Uso do m�todo
            Assert.Equal(-150, veiculo.VelocidadeAtual); // Assert - Valida��o
        }
        [Fact(DisplayName ="Testa tipo de ve�culo")]
        [Trait("Detalhe", "Tipo")]
        public void TestaTipoVeiculo()
        {
            var veiculo = new Veiculo();
            
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);

        }
        [Fact(Skip = "Teste ainda n�o implementado. Ignorar", DisplayName = "Teste de nome do propriet�rio") ]
        public void ValidaNomeProprietario()
        {

        }
    }
}
