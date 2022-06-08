namespace Domain.Commands
{
    public class MarkTodoAsDoneCommand : MarkTodoCommand
    {

        public MarkTodoAsDoneCommand()
        {
        }

        public MarkTodoAsDoneCommand(Guid id, string user) : base(id, user)
        {
            Id = id;
            User = user;
        }
    }
}
