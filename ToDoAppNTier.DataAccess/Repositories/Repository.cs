using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDoAppNTier.DataAccess.Contexts;
using ToDoAppNTier.DataAccess.Interfaces;

namespace ToDoAppNTier.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class, new()
{
    private readonly TodoContext _context;

    public Repository(TodoContext context)
    {
        _context = context;
    }
    
    

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetById(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
    {
        return asNoTracking
            ? await _context.Set<T>().SingleOrDefaultAsync(filter)
            : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
    }

    public IQueryable<T> GetQuery()
    {
        return _context.Set<T>().AsQueryable();
    }

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {

        _context.Set<T>().Update(entity);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}