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
            Assert.Equal(6, lista.Count);
        }

        [Fact]
        public void TestaInsercaoNovoClienteNoBancoDeDados()
        {
            //Arrange

            var cliente = new Cliente()
            {
                Nome = "Daniel Wesley",
                CPF = "452.552.922-90",
                Profissao = "Estagiario",
                Identificador = Guid.NewGuid()
            };

            //Act
            var adicionado = repositorio.Adicionar(cliente);

            //Assert
            Assert.True(adicionado);
        }

        [Fact]
        public void TestaAtualizacaoClienteNoBancoDeDados(){
            //Arrange
            var clienteAlteracao = repositorio.ObterPorId(4);

            //Act
            clienteAlteracao.Nome = "Pedro Queixada";
            var atualizado = repositorio.Atualizar(4, clienteAlteracao);

            //Assert 
            Assert.True(atualizado);
        }


    }
}

		
