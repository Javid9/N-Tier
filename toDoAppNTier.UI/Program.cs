using Microsoft.Extensions.FileProviders;
using ToDoAppNTier.Business.DependencyResolvers.Microsoft;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.AddDependencies();
services.AddControllersWithViews();


var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/node_modules"
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();