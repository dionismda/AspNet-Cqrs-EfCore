using Domain.Commands;
using Domain.Commands.Contracts;
using Domain.Entities.Contracts;
using Flunt.Notifications;

namespace Domain.Handler
{
    public abstract class BaseHandler : Notifiable
    {
        public static bool CommandIsValid(ICommand command)
        {
            return command.CommandIsValid();
        }

        public static GenericCommandResult GetCommandErrorResult(string message, ICommand command)
        {
            return new GenericCommandResult(false, message, command.GetNotifications());
        }

        public static GenericCommandResult GetCommandSuccessResult(string message, IEntity entity)
        {
            return new GenericCommandResult(true, message, entity);
        }

        public static GenericCommandResult? EntityIsNotNull(IEntity? entity, string message, ICommand command)
        {
            return (entity == null) ? GetCommandErrorResult(message, command) : null;
        }
    }
}
