using System.ComponentModel.DataAnnotations;

namespace MyTodo.ViewModels
{
    public class CreateTodoViewModel
    {
        public required string Title { get; set; }
    }
}
