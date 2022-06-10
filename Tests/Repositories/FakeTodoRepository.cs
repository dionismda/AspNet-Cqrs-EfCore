using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository<Todo>
    {
        public void Create(Todo entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public Todo? GetById(Guid id, string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(Todo entity)
        {
            throw new NotImplementedException();
        }

        Todo IRepository<Todo>.GetAll(string user)
        {
            throw new NotImplementedException();
        }
    }
}
