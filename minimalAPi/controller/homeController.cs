using Microsoft.AspNetCore.Mvc;

namespace Todo.Contollers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        //action
        [HttpGet("/")]
        public List<TodoModel> Get
        (
            [FromServices] AppDbContext context
        )
        {
            // está retornando todas as tarefas
            return context.Todo.ToList();
        }
    }
}