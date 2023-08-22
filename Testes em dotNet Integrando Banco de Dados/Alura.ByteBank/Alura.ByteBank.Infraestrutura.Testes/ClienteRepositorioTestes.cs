using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio repositorio; 
        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio,ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            repositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosOsClientes()
        {
            //Arrange
           
            repositorio.ObterTodos();
            //Act 
            List<Cliente> lista = repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count);
        }


    }
}
