using Domain.Commands.Contracts;

namespace Domain.Handler.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
