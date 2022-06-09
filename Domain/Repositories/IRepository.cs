using Domain.Entities.Contracts;

namespace Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        void Create(TEntity todo);
        void Update(TEntity todo);
        TEntity GetById(Guid id, string user);
    }
}
