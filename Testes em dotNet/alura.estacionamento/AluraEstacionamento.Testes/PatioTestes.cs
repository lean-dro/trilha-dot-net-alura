
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Xunit.Abstractions;

namespace AluraEstacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        
        //Setup
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;
        
        //Setup
        public PatioTestes(ITestOutputHelper saida)
        {
            SaidaConsoleTeste = saida;
            SaidaConsoleTeste.WriteLine("Construtor invocado ");
        }

        [Fact(DisplayName ="Teste N° 1")]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
           var estacionamento = new Patio();
            veiculo.Proprietario="Wagner Mancini";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "asd-9999";
            
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);
        }
        [Theory]
        [InlineData("Wagner Mancini", "ASD-1234", "preto", "gol")]
        [InlineData("Gabriel Barbosa", "FLA-2019", "azul", "fusca")]
        [InlineData("Edenilson", "BRA-2020", "vermelho", "Opala")]
        [InlineData("Pedro Silva", "ARG-2023", "azul", "Opala")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario,
                                                        string placa, string cor, string modelo)
        {
            // Arrange
            var patio = new Patio();
           
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(veiculo.Placa);


            double faturamento = patio.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Wagner Mancini", "ASD-1234", "preto", "gol")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario,
                                                        string placa, string cor, string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            //Act 
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert 
            Assert.Equal(placa, consultado.Placa);
        }
        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Wagner Mancini";
            veiculo.Placa = "ASD-1234";
            veiculo.Cor = "preto";
            veiculo.Modelo = "gol";
            estacionamento.RegistrarEntradaVeiculo(veiculo);


            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Wagner Mancini";
            veiculoAlterado.Placa = "ASD-1234";
            veiculoAlterado.Cor = "azul"; // Alteração
            veiculoAlterado.Modelo = "gol";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
           
        }

        // Limpa o objeto
        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}
