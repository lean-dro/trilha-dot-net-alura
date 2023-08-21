using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;


namespace AluraEstacionamento.Testes
{
    public class PatioTeste : IDisposable
    {
        private Patio estacionamento;
        private Veiculo veiculo = new Veiculo();
        private Operador operador = new Operador();
        
        public ITestOutputHelper Output { get; }
        public PatioTeste(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execução do Construtor");
            operador.Nome = "Barbieri";
            
            veiculo.Proprietario = "André Silva";
            veiculo.Placa = "ASD-9999";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";
            estacionamento = new Patio();
            estacionamento.Operador = operador;
        }


        [Fact(DisplayName = "Teste N° 1")]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            //var estacionamento = new Patio();
            
            veiculo.Proprietario = "Wagner Mancini";
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
           // var patio = new Patio();

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);


            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Wagner Mancini", "ASD-1234", "preto", "gol")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario,
                                                        string placa, string cor, string modelo)
        {
            // Arrange
            //var estacionamento = new Patio();
 
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
           
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            //Act 
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);
            
            //Assert 
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }
        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            // Arrange
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
            Output.WriteLine("Dispose invocado");
        }


    }
}