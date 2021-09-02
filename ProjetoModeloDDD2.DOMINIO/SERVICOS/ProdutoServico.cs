using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using ProjetoModeloDDD2.DOMINIO.INTERFACES.REPOSITORIOS;
using ProjetoModeloDDD2.DOMINIO.INTERFACES.SERVICOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.DOMINIO.SERVICOS
{
    public class ProdutoServico : ServicoBase<Produto>, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio) : base(produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepositorio.BuscarPorNome(nome);
        }
    }
}