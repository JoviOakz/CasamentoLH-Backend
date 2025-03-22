using CasamentoLH_Backend.Domain.Models;

namespace CasamentoLH_Backend.Domain.Services;

public interface IBaseService<T> where T : BaseEntity
{
    public Task<BaseResponse<object>> Create(object payload);
    public Task Delete(Guid id);
}