using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Store.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity 
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async void Create(T entity)
    {
        entity.DateCreated = DateTime.UtcNow;
        await _context.AddAsync(entity);
    }

    public void Update(T entity)
    {
        entity.DateUpdated = DateTime.UtcNow;
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DateDeleted = DateTime.UtcNow;
        _context.Remove(entity);
    }

    public async Task<T> Get(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }
}