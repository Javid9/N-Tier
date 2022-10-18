using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoAppNTier.Business.Services;
using ToDoAppNTier.DataAccess.Contexts;
using ToDoAppNTier.DataAccess.UnitofWork;

namespace ToDoAppNTier.Business.DependencyResolvers.Microsoft;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddDbContext<TodoContext>(opt =>
        {
            opt.UseSqlServer("Server=DESKTOP-NP0SP3H\\SQLEXPRESS;Initial Catalog=toDoNTier;Integrated Security=sspi;");
        });

        services.AddScoped<IUow, Uow>();
        services.AddScoped<IWorkService, WorkService>();
    }
    
    
}