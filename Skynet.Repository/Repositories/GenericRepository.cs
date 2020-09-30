using Microsoft.EntityFrameworkCore;
using Skynet.Data.Models;
using Skynet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Skynet.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public AcademyLockSmith_LiveContext context { get; set; }
        public DbSet<TEntity> dbSet { get; set; }

        public GenericRepository(AcademyLockSmith_LiveContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }


        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            return query.FirstOrDefault();
        }

        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public virtual IQueryable<TEntity> GetAsQuerable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool trackChanges = true)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;


                // context.Configuration.AutoDetectChangesEnabled = trackChanges;
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query);
                }
                else
                {
                    return query;
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //  context.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        public virtual TEntity GetByID(object id)
        {
            // IQueryable<TEntity> query = dbSet;
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void InsertRange(ICollection<TEntity> entity)
        {
            dbSet.AddRange(entity);
        }

        public virtual void deleteById(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);

        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Update(entityToUpdate);
            //dbSet.Attach(entityToUpdate);
            //context.Entry(entityToUpdate).State = EntityState.Modified;
            //context.Entry(entityToUpdate).Reload()
        }

        public virtual void Refresh(TEntity entityToRefresh)
        {

            context.Entry(entityToRefresh).Reload();

        }

        public void deleteRange(ICollection<TEntity> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public void updateRange(ICollection<TEntity> entity)
        {
            dbSet.UpdateRange(entity);
        }
    }
}
