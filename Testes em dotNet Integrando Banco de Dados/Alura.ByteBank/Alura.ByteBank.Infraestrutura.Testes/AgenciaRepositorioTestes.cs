using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio repositorio;
        public ITestOutputHelper SaidaConsoleTeste { get; set; }
        public AgenciaRepositorioTestes(ITestOutputHelper saidaConsole)
        {
            SaidaConsoleTeste = saidaConsole;
            SaidaConsoleTeste.WriteLine("Construtor executado com sucesso");

            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();
            repositorio = provedor.GetService<IAgenciaRepositorio>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterAgenciaPeloId(int id)
        {
            //Act
            Agencia agenciaObtida = repositorio.ObterPorId(id);

            //Assert
            Assert.Equal(agenciaObtida.Id, id);
        }

        [Fact]
        public void TestaObterTodasAgencias()
        {
            //Act
            List<Agencia> agencias = repositorio.ObterTodos();

            //Assert
            Assert.True(agencias.Count > 0);
        }

        [Fact]
        public void TestaAdicionarAgenciaNoBancoDeDados()
        {
            //Arrange
            var agencia = new Agencia()
            {
                Identificador = Guid.NewGuid(),
                Nome = "Agência Maraca",
                Endereco = "Rua Professor Eurico Rabelo",
                Numero = 231
            };

            //Act
            var adicionado = repositorio.Adicionar(agencia);

            //Assert
            Assert.True(adicionado);
        }
        [Fact]
        public void TestaAtualizarAgenciaNoBancoDeDados() {
            //Arrange
            var agenciaDesejada = repositorio.ObterPorId(1);

            agenciaDesejada.Numero = 123;
            //Act
            var atualizado = repositorio.Atualizar(1, agenciaDesejada);

            //Assert
            Assert.True(atualizado);


        }
        [Fact]
        public void TestaRemoverInformacaoDeterminadaAgencia()
        {
            //Arrange

            //
            var atualizado = repositorio.Excluir(6);

            //Assert 
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaExcecaoConsultaAgenciaPorId()
        {
            //Assert
            Assert.Throws<FormatException>(
                () => repositorio.ObterPorId(10)
             );
        }
       
        [Fact]
        public void TestaAdicionarAgenciaMock()
        {
            //Arrange
            var agencia = new Agencia()
            {
                Nome = "Agência Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();
            
            // act 
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //Assert
            Assert.True(adicionado);
        }
       
        //Com a lib Moq:
        [Fact]
        public void TestaObterAgenciaMock()
        {
            //Arrange
            var byteBankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = byteBankRepositorioMock.Object;



            // act 
            var lista = mock.BuscarAgencias();


            //Assert
            byteBankRepositorioMock.Verify(b => b.BuscarAgencias());
        }
    }
}
