using Domain.Commands;
using Domain.Entities;
using Domain.Handler;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/todo")]
    [Consumes("application/json")]
    [Produces("application/json")]
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
            return _todoRepository.GetAll("UserTest");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<Todo> GetAllDone()
        {
            return _todoRepository.GetAllDone("UserTest");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<Todo> GetAllUndone()
        {
            return _todoRepository.GetAllUndone("UserTest");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<Todo> GetAllDoneToday()
        {
            return _todoRepository.GetByPeriod("UserTest", DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<Todo> GetAllUndoneToday()
        {
            return _todoRepository.GetByPeriod("UserTest", DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<Todo> GetAllDoneTomorrow()
        {
            return _todoRepository.GetByPeriod("UserTest", DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<Todo> GetAllUndoneTomorrow()
        {
            return _todoRepository.GetByPeriod("UserTest", DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "UserTest";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "UserTest";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "UserTest";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "UserTest";
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}
