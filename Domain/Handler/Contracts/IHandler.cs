using Domain.Commands.Contracts;

namespace Domain.Handler.Contracts
{
    public interface IHandler<TCommand> where TCommand : ICommand
    {
        ICommandResult Handle(TCommand command);
    }
}
