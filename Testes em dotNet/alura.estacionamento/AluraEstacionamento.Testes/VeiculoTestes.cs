using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace AluraEstacionamento.Testes
{
    // Padr�o AAA
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
            
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // Arrange - Inicia o ambiente/
            veiculo.Acelerar(100); // Act - Uso do m�todo
            Assert.Equal(1000, veiculo.VelocidadeAtual); // Assert - Valida��o
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
           // Arrange - Inicia o ambiente/cen�rio
            veiculo.Frear(10); // Act - Uso do m�todo
            Assert.Equal(-150, veiculo.VelocidadeAtual); // Assert - Valida��o
        }
        [Fact(DisplayName ="Testa tipo de ve�culo")]
        [Trait("Detalhe", "Tipo")]
        public void TestaTipoVeiculo()
        {
           
            
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);

        }
        [Fact(Skip = "Teste ainda n�o implementado. Ignorar", DisplayName = "Teste de nome do propriet�rio") ]
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
            Assert.Contains("Ficha do ve�culo:", dados);
        }

        

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)

             ) ;
        }
        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            string placa = "ASDF8888";
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
             ) ;
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        } 

        public void TestaUltimosDigitosDaPlacaSaoNumeros()
        {
            string placa = "AAAAAAAAA";
            var mensagemDeErro = Assert.Throws<System.FormatException>(
            () => new Veiculo().Placa = placa
                );
            Assert.Equal("Do 5� ao 8� caractere deve-se ter um n�mero!", mensagemDeErro.Message);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado ");
           
        }


    }
}
