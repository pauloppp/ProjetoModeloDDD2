using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD2.DOMINIO.INTERFACES.SERVICOS
{
    public interface IClienteServico : IServicoBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
       
    }
}
