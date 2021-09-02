using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD2.APLICACAO.INTERFACES
{
    public interface IProdutoAppServico : IAppServicoBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
