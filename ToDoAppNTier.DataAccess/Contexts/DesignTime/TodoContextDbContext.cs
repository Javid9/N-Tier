using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ToDoAppNTier.DataAccess.Contexts.DesignTime;

public class TodoContextDbContext:IDesignTimeDbContextFactory<TodoContext>
{
    public TodoContext CreateDbContext(string[] args)
    {
        var builder=new DbContextOptionsBuilder<TodoContext>();
        builder.UseSqlServer("Server=DESKTOP-NP0SP3H\\SQLEXPRESS;Initial Catalog=toDoNTier;Integrated Security=sspi;");
        return new TodoContext(builder.Options);
    }
  
}