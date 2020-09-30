namespace Skynet.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        dynamic Save();
    }
}
