using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD2.DOMINIO.INTERFACES.REPOSITORIOS
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
