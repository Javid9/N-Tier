using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ToDoAppNTier.DataAccess.Configurations;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.DataAccess.Contexts;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkConfiguration());
    }
    


    public DbSet<Work> Works { get; set; } = null!;
    
}