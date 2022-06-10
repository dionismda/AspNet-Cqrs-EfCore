using Domain.Entities.Contracts;

namespace Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        TEntity? GetById(Guid id, string user);
        TEntity GetAll(string user);
    }
}
