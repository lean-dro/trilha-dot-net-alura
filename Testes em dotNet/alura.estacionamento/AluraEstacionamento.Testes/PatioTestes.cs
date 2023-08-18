
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

    }
}
