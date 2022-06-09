namespace Domain.Entities
{
    public class Todo : Entity
    {
        public Todo(string title, string user, DateTime date)
        {
            Title = title;
            Done = false;
            User = user;
            Date = date;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public void SetDone(bool done)
        {
            Done = done;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }
    }
}
