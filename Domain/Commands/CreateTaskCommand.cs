using Domain.Commands.Contracts;

namespace Domain.Commands
{
    public class CreateTaskCommand : ICommand
    {
        public CreateTaskCommand()
        {
        }

        public CreateTaskCommand(string title, DateTime date, string user)
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
            throw new NotImplementedException();
        }
    }
}
