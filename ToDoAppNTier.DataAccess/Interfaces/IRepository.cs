using System.Linq.Expressions;

namespace ToDoAppNTier.DataAccess.Interfaces;

public interface IRepository<T> where T: class, new()
{
    Task<List<T>> GetAll();
    Task<T> GetById(object id);
    Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking= false);
    IQueryable<T> GetQuery();
    Task Create(T entity);
    void Update(T entity);
    void Remove(T entity);
    

}