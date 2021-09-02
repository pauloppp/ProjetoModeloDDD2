using ProjetoModeloDDD2.APLICACAO.INTERFACES;
using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using ProjetoModeloDDD2.DOMINIO.INTERFACES.SERVICOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.APLICACAO
{
    public class ProdutoAppServico : AppServicoBase<Produto>, IProdutoAppServico
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoAppServico(IProdutoServico produtoServico): base(produtoServico)
        {
            _produtoServico = produtoServico;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoServico.BuscarPorNome(nome);
        }
    }
}