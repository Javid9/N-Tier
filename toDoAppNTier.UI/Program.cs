using ToDoAppNTier.Business.DependencyResolvers.Microsoft;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var services = builder.Services;


services.AddDependencies();

app.MapGet("/", () => "Hello World!");

app.Run();