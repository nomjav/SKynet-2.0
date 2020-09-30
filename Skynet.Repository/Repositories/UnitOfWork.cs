using Skynet.Data.Models;
using Skynet.Repository.Interfaces;
using System;
using System.Collections;

namespace Skynet.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public AcademyLockSmith_LiveContext context { get; set; }
        private bool disposed = false;
        public UnitOfWork(AcademyLockSmith_LiveContext _context)
        {
            context = _context;
        }
        private Hashtable _repositories;
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }
        public dynamic Save()
        {
            try
            {
                context.SaveChanges();
                return "data has been saved in db";
            }

            catch (Exception e)
            {
                return "exce3ption occured in unit of work";
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
