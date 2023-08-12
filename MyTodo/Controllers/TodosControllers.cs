using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTodo.Data;
using MyTodo.Models;
using MyTodo.ViewModels;

namespace MyTodo.Controllers
{
    [ApiController]
    [Route("v1/todos")]

    public class TodosController : ControllerBase
    {
        //[HttpGet]
        //[Route("todos")]
        //public List<Todo> GetAll()
        //{
        //    return new List<Todo>();
        //}

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] AppDbContext context)
        {
            var todos = await context.Todos.AsNoTracking().ToListAsync();
            return todos == null ? NotFound() : Ok(todos);
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context, [FromRoute] int id)
        {
            var todo = await context.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost("/")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context, [FromBody] CreateTodoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = new Todo
            {
                Title = viewModel.Title,
                IsDone = false,
            };

            try
            {
                await context.Todos.AddAsync(todo);
                await context.SaveChangesAsync();
                return Created($"v1/todos/{todo.Id}", todo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTodoViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null)
                return NotFound();

            try
            {
                todo.Title = model.Title;

                context.Todos.Update(todo);
                await context.SaveChangesAsync();
                return Ok(todo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return NotFound();

            try
            {
                _ = context.Todos.Remove(todo);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
