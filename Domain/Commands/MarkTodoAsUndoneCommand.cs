namespace Domain.Commands
{
    public class MarkTodoAsUndoneCommand : MarkTodoCommand
    {

        public MarkTodoAsUndoneCommand()
        {
        }

        public MarkTodoAsUndoneCommand(Guid id, string user) : base(id, user)
        {
            Id = id;
            User = user;
        }

    }
}
