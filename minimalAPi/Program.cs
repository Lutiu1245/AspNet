var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/nome/{nome}", (string nome) => Results.Ok("Hello " + nome));

app.MapPost("/", (User user) =>{
    return Results.Ok(user);
});
app.Run();

public class User {
    public int Id { get; set; }
    public string? Nome { get; set; }
}