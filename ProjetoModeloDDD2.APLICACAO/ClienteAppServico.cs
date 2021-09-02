using ProjetoModeloDDD2.APLICACAO.INTERFACES;
using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using ProjetoModeloDDD2.DOMINIO.INTERFACES.SERVICOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.APLICACAO
{
    public class ClienteAppServico : AppServicoBase<Cliente>, IClienteAppServico
    {
        private readonly IClienteServico _clienteServico;

        public ClienteAppServico(IClienteServico clienteServico) : base(clienteServico)
        {
            _clienteServico = clienteServico;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteServico.ObterClientesEspeciais(_clienteServico.GetAll());
        }
    }
}