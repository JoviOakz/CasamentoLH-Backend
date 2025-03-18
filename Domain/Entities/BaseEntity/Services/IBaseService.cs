using CasamentoLH_Backend.Domain.Models;

namespace CasamentoLH_Backend.Domain.Services;

public interface IBaseService<T> where T : BaseEntity
{
    public Task Delete(Guid id);
}