using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository<Todo>
    {

        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Todo entity)
        {
            _context.Todo.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Todo> GetAll(string user)
        {
            return _context.Todo
                .AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<Todo> GetAllDone(string user)
        {
            return _context.Todo
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<Todo> GetAllUndone(string user)
        {
            return _context.Todo
                .AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);
        }

        public Todo? GetById(Guid id, string user)
        {
            return _context.Todo
                .FirstOrDefault(TodoQueries.GetById(id, user));
        }

        public IEnumerable<Todo> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Todo
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }

        public void Update(Todo entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        Todo IRepository<Todo>.GetAll(string user)
        {
            throw new NotImplementedException();
        }
    }
}
