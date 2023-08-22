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
    public class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio repositorio;

        public ContaCorrenteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            repositorio = provedor.GetService<IContaCorrenteRepositorio>();
        }

        [Theory]
        [InlineData (1)]
        [InlineData (2)]
        public void TestaObterContaCorrentePeloId(int id)
        {
            //Arrange

            // act 
            ContaCorrente contaObtida = repositorio.ObterPorId(id);
            int idConta = contaObtida.Id;


            // Assert
            Assert.Equal(idConta, id);
        }
        [Fact]
        public void TestaObterTodasAsContas()
        {
            //Act
            List<ContaCorrente> contas = repositorio.ObterTodos();
            
            //Assert
            Assert.True(contas.Count > 0);
        }

        [Fact]        
        public void TestaInsereUmaNovaContaCorrenteNoBancoDeDados()
        {
            //Arrange
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome="Kent Nelson",
                    CPF="486.074.980-45",
                    Identificador =Guid.NewGuid(),
                    Profissao = "Bancário",
                    Id=1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Central Coast City",
                    Identificador = Guid.NewGuid(),
                    Id=1,
                    Endereco = "Rua das Flores,25",
                    Numero = 147
                }
            };

            //act 
            var adicionado = repositorio.Adicionar(conta);

            //Assert 
            Assert.True(adicionado);
        }

        [Fact]
        public void TestaAtualizacaoSaldoDeterminadaConta()
        {
            //Arrang 
            var conta = repositorio.ObterPorId(1);
            double saldoNovo = 1.5;
            conta.Saldo *= saldoNovo;

            // Act 
            var atualizado = repositorio.Atualizar(1, conta);

            //Assert
            Assert.True(atualizado);
        }
    }
}



