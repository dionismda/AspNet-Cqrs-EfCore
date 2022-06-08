using Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand()
        {
        }

        public CreateTodoCommand(string title, DateTime date, string user)
        {
            Title = title;
            Date = date;
            User = user;
        }

        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

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
