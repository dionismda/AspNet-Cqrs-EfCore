using Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand()
        {
        }

        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
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
                     .HasMinLen(Title, 3, "Title", "Descreva mais a sua tarefa!")
                     .HasMinLen(User, 6, "User", "Usuário inválido!")
            );
        }
    }
}
