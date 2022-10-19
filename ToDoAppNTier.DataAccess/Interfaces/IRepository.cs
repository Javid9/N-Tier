using System.Linq.Expressions;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.DataAccess.Interfaces;

public interface IRepository<T> where T: BaseEntity
{
    Task<List<T>> GetAll();
    Task<T> GetById(object id);
    Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking= false);
    IQueryable<T> GetQuery();
    Task Create(T entity);
    void Update(T entity);
    void Remove(object id);
    

}