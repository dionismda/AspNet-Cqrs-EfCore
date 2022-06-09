using Domain.Entities;
using Domain.Entities.Contracts;

namespace Domain.Repositories
{
    public interface ITodoRepository<Todo> : IRepository<IEntity>
    {

    }
}
