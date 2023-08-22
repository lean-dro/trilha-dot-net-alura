using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Infraestrutura.Testes.Servico
{
    public interface IByteBankRepositorio
    {
        public List<Cliente> BuscarClientes();
        public List<Agencia> BuscarAgencias();
        public List<ContaCorrente> BuscarContaCorrentes();
    }
}
