using CasamentoLH_Backend.Domain.Models;

namespace CasamentoLH_Backend.Domain.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    public Task<T?> GetByIdAsync(Guid id);
    public IQueryable<T> GetAll();
    public IQueryable<T> GetAllNoTracking();
    public IQueryable<T> GetAllDeleted();
    public IQueryable<T> GetAllDeletedNoTracking();
    public Task<T> AddAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<T> UpsertAsync(T entity);
    public Task SoftDeleteAsync(Guid id);
    public Task DeleteAsync(Guid id);
    public Task SaveAsync();
}