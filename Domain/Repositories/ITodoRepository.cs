using Domain.Entities.Contracts;

namespace Domain.Repositories
{
    public interface ITodoRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll(string user);
        IEnumerable<TEntity> GetAllDone(string user);
        IEnumerable<TEntity> GetAllUndone(string user);
        IEnumerable<TEntity> GetByPeriod(string user, DateTime date, bool done);
    }
}