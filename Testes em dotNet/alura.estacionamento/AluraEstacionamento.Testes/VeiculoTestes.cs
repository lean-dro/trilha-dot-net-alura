using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace AluraEstacionamento.Testes
{
    // Padrão AAA
    // Arrange
    // Act
    // Assert
    public class VeiculoTestes : IDisposable
    {
        
        // Setup
        private Veiculo veiculo;
        
        public ITestOutputHelper SaidaConsoleTeste;
        public VeiculoTestes(ITestOutputHelper saida)
        {
            SaidaConsoleTeste = saida;
            SaidaConsoleTeste.WriteLine("Construtor invocado ");
            veiculo = new Veiculo();
            SaidaConsoleTeste.WriteLine(veiculo.ToString());
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // Arrange - Inicia o ambiente/
            veiculo.Acelerar(100); // Act - Uso do método
            Assert.Equal(1000, veiculo.VelocidadeAtual); // Assert - Validação
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
           // Arrange - Inicia o ambiente/cenário
            veiculo.Frear(10); // Act - Uso do método
            Assert.Equal(-150, veiculo.VelocidadeAtual); // Assert - Validação
        }
        [Fact(DisplayName ="Testa tipo de veículo")]
        [Trait("Detalhe", "Tipo")]
        public void TestaTipoVeiculo()
        {
           
            
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);

        }
        [Fact(Skip = "Teste ainda não implementado. Ignorar", DisplayName = "Teste de nome do proprietário") ]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }
        [Fact]
        public void ImprimeAFichaDeInformacaoDoVeiculo()
        {
            //arrange
        
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Placa = "ZAP-1234";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //act
            string dados = veiculo.ToString();
            Console.WriteLine("dados");
            //assert
            Assert.Contains("Ficha do veículo:", dados);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado ");
            SaidaConsoleTeste.WriteLine(veiculo.ToString());
        }

 
    }
}
