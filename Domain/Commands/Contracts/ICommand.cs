using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Commands.Contracts
{
    public interface ICommand : IValidatable
    {
        bool CommandIsValid();
        IReadOnlyCollection<Notification> GetNotifications();
    }
}
