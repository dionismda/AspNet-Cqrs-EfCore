using Domain.Entities;
using Domain.Entities.Contracts;
using Domain.Repositories;
using System;

namespace Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository<Todo>
    {
        public void Create(IEntity todo)
        {
        }

        public IEntity GetById(Guid id, string user)
        {
            return new Todo("Titulo tarefa", "UserTest", DateTime.Now);
        }

        public void Update(IEntity todo)
        {
        }
    }
}
