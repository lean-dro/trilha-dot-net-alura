using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio repositorio;
        public AgenciaRepositorioTestes()
        {
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
            var atualizado = repositorio.Excluir(5);

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
    }
}
