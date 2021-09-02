using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using ProjetoModeloDDD2.DOMINIO.INTERFACES.REPOSITORIOS;
using ProjetoModeloDDD2.DOMINIO.INTERFACES.SERVICOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.DOMINIO.SERVICOS
{
    public class ClienteServico : ServicoBase<Cliente>, IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio) : base(clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
        {
           return clientes.Where(c => c.ClienteEspecial(c));
        }
    }
}