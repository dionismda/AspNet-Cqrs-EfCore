using Domain.Commands;
using Domain.Entities;
using Domain.Handler;
using Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/todo")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    public class TodoController : ControllerBase
    {

        private readonly ITodoRepository<Todo> _todoRepository ;
        public TodoController(ITodoRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }


        [Route("")]
        [HttpGet]
        public IEnumerable<Todo> GetAll()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _todoRepository.GetAll(user);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<Todo> GetAllDone()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _todoRepository.GetAllDone(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<Todo> GetAllUndone()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _todoRepository.GetAllUndone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<Todo> GetAllDoneToday()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _todoRepository.GetByPeriod(user, DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<Todo> GetAllUndoneToday()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _todoRepository.GetByPeriod(user, DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<Todo> GetAllDoneTomorrow()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _todoRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<Todo> GetAllUndoneTomorrow()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _todoRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}
