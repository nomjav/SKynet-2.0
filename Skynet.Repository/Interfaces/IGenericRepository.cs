using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Skynet.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IQueryable<TEntity> GetAsQuerable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool trackChanges = true);
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void InsertRange(ICollection<TEntity> entity);
        void deleteById(object id);
        void Delete(TEntity entityToDelete);
        void deleteRange(ICollection<TEntity> entity);
        void Update(TEntity entityToUpdate);
        void updateRange(ICollection<TEntity> entity);
        void Refresh(TEntity entityToRefresh);
        DbSet<TEntity> dbSet { get; set; }
    }
}
