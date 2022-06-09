using Domain.Commands;
using Domain.Commands.Contracts;
using Domain.Entities.Contracts;
using Domain.Repositories;
using Flunt.Notifications;

namespace Domain.Handler
{
    public abstract class BaseHandler : Notifiable
    {
        private readonly IRepository<IEntity> _repository;

        public BaseHandler(IRepository<IEntity> repository)
        {
            _repository = repository;
        }

        public bool CommandIsValid(ICommand command)
        {
            return command.CommandIsValid();
        }

        public GenericCommandResult GetCommandErrorResult(string message, ICommand command)
        {
            return new GenericCommandResult(false, message, command.GetNotifications());
        }

        public GenericCommandResult GetCommandSuccessResult(string message, IEntity entity)
        {
            return new GenericCommandResult(true, message, entity);
        }
    }
}
