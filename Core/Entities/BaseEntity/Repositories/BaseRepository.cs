using CasamentoLH_Backend.Config;
using CasamentoLH_Backend.Core.Middlewares.ErrorHandler.Errors;
using CasamentoLH_Backend.Domain.Models;
using CasamentoLH_Backend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CasamentoLH_Backend.Core.Repositories;

public class BaseRepository<T>(CasamentoLHContext context) : IBaseRepository<T> where T : BaseEntity
{
    protected readonly CasamentoLHContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.Where(e => e.DeletedAt == null).SingleOrDefaultAsync(e => e.Id == id);
    public IQueryable<T> GetAll() => _dbSet.Where(e => e.DeletedAt == null);
    public IQueryable<T> GetAllNoTracking() => _dbSet.Where(e => e.DeletedAt == null).AsNoTracking();
    public IQueryable<T> GetAllDeleted() => _dbSet.Where(e => e.DeletedAt != null);
    public IQueryable<T> GetAllDeletedNoTracking() => _dbSet.Where(e => e.DeletedAt != null).AsNoTracking();

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var existingEntity = await GetByIdAsync(entity.Id) ?? 
            throw new NotFoundException($"Entity with ID {entity.Id} not found!");

        existingEntity.UpdatedAt = DateTime.UtcNow;
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        return existingEntity;
    }

    public async Task<T> UpsertAsync(T entity)
    {
        var existingEntity = await GetByIdAsync(entity.Id);
        if (existingEntity is not null)
        {
            existingEntity.UpdatedAt = DateTime.UtcNow;
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
        else
        {
            await _dbSet.AddAsync(entity);
        }
        return existingEntity ?? entity;
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        var existingEntity = await GetByIdAsync(id) ?? 
            throw new NotFoundException($"Entity with ID {id} not found.");

        existingEntity.DeletedAt = DateTime.UtcNow;
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingEntity = await GetByIdAsync(id) ?? 
            throw new NotFoundException($"Entity with ID {id} not found.");

        _dbSet.Remove(existingEntity);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
