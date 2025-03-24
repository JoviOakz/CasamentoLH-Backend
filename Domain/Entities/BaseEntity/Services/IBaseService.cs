using CasamentoLH_Backend.Domain.Models;

namespace CasamentoLH_Backend.Domain.Services;

public interface IBaseService<T> where T : BaseEntity
{
    public Task<BaseResponse<object>> GetByIdAsync(Guid id);
    public BaseResponse<IEnumerable<object>> GetAll();
    public Task<BaseResponse<object>> Create(object payload);
    public Task<BaseResponse<object>> Update(Guid id, object payload);
    public Task Delete(Guid id);
}