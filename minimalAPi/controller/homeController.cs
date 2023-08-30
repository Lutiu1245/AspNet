using Microsoft.AspNetCore.Mvc;

namespace Todo.Contollers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        //action
        [HttpGet("/")]
        public List<TodoModel> Get([FromServices] AppDbContext context)
        {
            // está retornando todas as tarefas
            return context.Todo.ToList();
        }
        [HttpGet("/{id}")]
        public TodoModel GetByid([FromServices] AppDbContext context, int id)
        {
            // está retornando uma tarefa
            return context.Todo.Find(id);
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
        public TodoModel Put([FromRoute] int id, [FromBody] TodoModel model, [FromServices] AppDbContext context)
        {
            // está atualizando uma tarefa
            var todo = context.Todo.Find(id);
            todo.Title = model.Title;
            todo.Done = model.Done;
            context.Todo.Update(todo);
            context.SaveChanges();
            return todo;
        }
        [HttpDelete("/{id}")]
        public TodoModel Delete(int id, [FromServices] AppDbContext context)
        {
            var todo = context.Todo.Find(id);
            context.Todo.Remove(todo);
            context.SaveChanges();
            return todo;
        }
    }
}