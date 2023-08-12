namespace MyTodo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}