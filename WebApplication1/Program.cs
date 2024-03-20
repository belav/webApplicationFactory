var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! " + builder.Configuration["Instance"]);

app.Run();

public partial class Program { }

public class HelloWorldProgram : Program { }
