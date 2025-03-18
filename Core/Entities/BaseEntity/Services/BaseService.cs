using CasamentoLH_Backend.Domain.Models;
using CasamentoLH_Backend.Domain.Repositories;
using CasamentoLH_Backend.Domain.Services;

namespace CasamentoLH_Backend.Core.Services;

public class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T> where T : BaseEntity
{
    private readonly IBaseRepository<T> _repo = repository;

    public async Task Delete(Guid id)
    {
        await _repo.SoftDeleteAsync(id);
        await _repo.SaveAsync();
    }
}
