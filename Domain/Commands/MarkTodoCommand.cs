using Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Commands
{
    public class MarkTodoCommand : Notifiable, ICommand
    {

        public MarkTodoCommand()
        {
        }

        public MarkTodoCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public bool CommandIsValid()
        {
            Validate();
            return Invalid;
        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                      .HasMinLen(User, 6, "User", "Usuário Inválido")
            );
        }
    }
}
