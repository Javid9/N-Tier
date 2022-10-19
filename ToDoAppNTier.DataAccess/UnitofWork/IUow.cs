using ToDoAppNTier.DataAccess.Interfaces;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.DataAccess.UnitofWork;

public interface IUow
{
    IRepository<T> GetRepository<T>() where T : BaseEntity;

    Task SaveChanges();
}
