using ProjetoModeloDDD2.DOMINIO.INTERFACES;
using ProjetoModeloDDD2.DOMINIO.INTERFACES.REPOSITORIOS;
using ProjetoModeloDDD2.INFRA.DADOS.CONTEXTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.INFRA.DADOS.REPOSITORIOS
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected ProjetoModeloContexto Db = new ProjetoModeloContexto();
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges(); ;
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}