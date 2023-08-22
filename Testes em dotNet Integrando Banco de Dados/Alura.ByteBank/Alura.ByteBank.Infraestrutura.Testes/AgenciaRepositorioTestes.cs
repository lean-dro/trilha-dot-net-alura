using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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


    }
}
