using Domain.Commands;
using Domain.Commands.Contracts;
using Domain.Entities;
using Domain.Handler.Contracts;
using Domain.Repositories;

namespace Domain.Handler
{
    public class TodoHandler : BaseHandler,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {

        private readonly ITodoRepository<Todo> _todoRepository;

        public TodoHandler(ITodoRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            if (CommandIsValid(command))
            {
                return GetCommandErrorResult("Erro ao salvar a tarefa!", command);
            }

            Todo todo = new Todo(command.Title, command.User, command.Date);

            _todoRepository.Create(todo);

            return GetCommandSuccessResult("Tarefa salva com sucesso!", todo);

        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            if (CommandIsValid(command))
            {
                return GetCommandErrorResult("Erro ao editar a tarefa!", command);
            }

            Todo? todo = (Todo?)_todoRepository.GetById(command.Id, command.User);
            EntityIsNotNull(todo, "Item para edição não encontrado", command);

            todo.SetTitle(command.Title);

            _todoRepository.Update(todo);

            return GetCommandSuccessResult("Tarefa editada com sucesso!", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            if (CommandIsValid(command))
            {
                return GetCommandErrorResult("Erro ao editar a tarefa!", command);
            }

            Todo? todo = (Todo?)_todoRepository.GetById(command.Id, command.User);
            EntityIsNotNull(todo, "Item para edição não encontrado", command);

            todo.SetDone(true);
            _todoRepository.Update(todo);

            return GetCommandSuccessResult("Tarefa editada com sucesso!", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            if (CommandIsValid(command))
            {
                return GetCommandErrorResult("Erro ao editar a tarefa!", command);
            }

            Todo? todo = (Todo?)_todoRepository.GetById(command.Id, command.User);
            EntityIsNotNull(todo, "Item para edição não encontrado", command);

            todo.SetDone(false);
            _todoRepository.Update(todo);

            return GetCommandSuccessResult("Tarefa editada com sucesso!", todo);
        }
    }
}
