using AutoMapper;
using CasamentoLH_Backend.Core.Middlewares.ErrorHandler.Errors;
using CasamentoLH_Backend.Domain.Models;
using CasamentoLH_Backend.Domain.Repositories;
using CasamentoLH_Backend.Domain.Services;

namespace CasamentoLH_Backend.Core.Services;

public class BaseService<T>(IBaseRepository<T> repository, IMapper mapper) : IBaseService<T> where T : BaseEntity
{
    private readonly IBaseRepository<T> _repo = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<object>> GetByIdAsync(Guid id)
    {
        var obj = await _repo.GetByIdAsync(id)
            ?? throw new NotFoundException($"Entity with ID {id} not found.");
        return new BaseResponse<object>(
            obj.DTO,
            $"{typeof(T)} found!",
            $"{typeof(T)} encontrado!"
        );
    }

    public BaseResponse<IEnumerable<object>> GetAll()
    {
        var objs = _repo.GetAllNoTracking().Select(o => o.DTO);
        return new BaseResponse<IEnumerable<object>>(
            objs,
            "Objects found!",
            "Objetos encontrados!"
        );
    }

    public async Task<BaseResponse<object>> Create(object payload)
    {
        var obj = _mapper.Map<T>(payload);
        var createdObj = await _repo.AddAsync(obj);
        await _repo.SaveAsync();

        return new BaseResponse<object>(
            createdObj.DTO,
            $"{typeof(T)} created successfully!",
            $"{typeof(T)} criado com sucesso!"
        );
    }

    public async Task<BaseResponse<object>> Update(Guid id, object payload)
    {
        var obj = await _repo.GetByIdAsync(id) ?? throw new NotFoundException($"Entity with ID {id} not found.");
        var updatedObj = _mapper.Map(payload, obj) ?? throw new Exception();

        var result = await _repo.UpdateAsync(updatedObj);
        await _repo.SaveAsync();

        return new BaseResponse<object>(
            result.DTO,
            $"{nameof(T)} updated successfully!",
            $"{nameof(T)} atualizado com sucesso!"
        );
    }

    public async Task Delete(Guid id)
    {
        await _repo.SoftDeleteAsync(id);
        await _repo.SaveAsync();
    }
}
