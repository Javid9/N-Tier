using ToDoAppNTier.DataAccess.Interfaces;

namespace ToDoAppNTier.DataAccess.UnitofWork;

public interface IUow
{
    IRepository<T> GetRepository<T>() where T : class, new ();

    Task SaveChanges();
}
