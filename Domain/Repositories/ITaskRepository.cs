using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(Todo todo);
        void Update(Todo todo);
    }
}
