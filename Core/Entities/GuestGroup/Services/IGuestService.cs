using CasamentoLH_Backend.Api.Payloads;
using CasamentoLH_Backend.Domain.Models;

namespace CasamentoLH_Backend.Domain.Services;

public interface IGuestService : IBaseService<Guest>
{
    public Task<BaseResponse<IEnumerable<GuestGroupDTO>>> CreateManyGuests(IEnumerable<GuestGroupPayload> payload);
}