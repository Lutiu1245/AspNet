using Microsoft.AspNetCore.Mvc;

namespace Todo.Contollers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        //action
        [HttpGet("/")]
        public string Get()
        {
            return "Hello World!";
        }
    }
}