using Domain.Commands;
using Domain.Commands.Contracts;
using Domain.Entities;
using Domain.Handler.Contracts;
using Domain.Repositories;
using Flunt.Notifications;

namespace Domain.Handler
{
    public class TodoHandler : Notifiable,
        IHandler<CreateTodoCommand>
    {

        private readonly ITodoRepository _todoRepository;

        public TodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro ao salvar a tarefa!", command.Notifications);
            }

            Todo todo = new Todo(command.Title, command.User, command.Date);

            _todoRepository.Create(todo);

            return new GenericCommandResult(true, "Tarefa salva com sucesso!", todo);

        }
    }
}
