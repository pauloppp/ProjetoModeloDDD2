using ProjetoModeloDDD2.APLICACAO.INTERFACES;
using ProjetoModeloDDD2.DOMINIO.INTERFACES.SERVICOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.APLICACAO
{
    public class AppServicoBase<TEntity> : IDisposable, IAppServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _servicoBase;

        public AppServicoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Add(TEntity obj)
        {
            _servicoBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _servicoBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _servicoBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _servicoBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _servicoBase.Remove(obj);
        }
        
        public void Dispose()
        {
            _servicoBase.Dispose();
        }
    }
}