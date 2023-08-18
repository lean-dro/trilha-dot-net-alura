
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace AluraEstacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
           var estacionamento = new Patio();
           var veiculo = new Veiculo();
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
        public void ValidaFaturamentoComVariosVeiculos(string proprietario,
                                                        string placa, string cor, string modelo)
        {
            // Arrange
            var patio = new Patio();
            var veiculo = new Veiculo();
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
    }
}
