using Microsoft.AspNetCore.Mvc;

namespace Todo.Contollers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        //action
        [HttpGet("/")]
        public List<TodoModel> Get([FromServices] AppDbContext context)
            => context.Todo.ToList();

        [HttpGet("/{id}")]
        public IActionResult GetByid([FromServices] AppDbContext context, int id)
        {
            // está retornando uma tarefa
            var todo = context.Todo.Find(id);
            if(todo == null)
                return NotFound();
            return Created($"/{todo.Id}", todo);
        }
        [HttpPost("/")]
        public TodoModel Post(
                       [FromServices] AppDbContext context,
                       [FromBody] TodoModel model)
        {
            // está adicionando uma nova tarefa
            context.Todo.Add(model);
            context.SaveChanges();
            return model;
        }
        [HttpPut("/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoModel model, [FromServices] AppDbContext context)
        {
            // está atualizando uma tarefa
            var todo = context.Todo.Find(id);
            if(todo == null)
                return NotFound();

            todo.Title = model.Title;
            todo.Done = model.Done;
            context.Todo.Update(todo);
            context.SaveChanges();
            return Ok(todo);
        }
        [HttpDelete("/{id}")]
        public IActionResult Delete(int id, [FromServices] AppDbContext context)
        {
            var todo = context.Todo.Find(id);
            if(todo == null)
                return NotFound();

            context.Todo.Remove(todo);
            context.SaveChanges();
            return Ok(todo);
        }
    }
}