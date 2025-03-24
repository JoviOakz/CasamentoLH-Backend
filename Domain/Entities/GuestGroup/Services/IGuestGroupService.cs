using CasamentoLH_Backend.Api.Payloads;
using CasamentoLH_Backend.Domain.Models;

namespace CasamentoLH_Backend.Domain.Services;

public interface IGuestGroupService : IBaseService<GuestGroup>
{
    public Task<BaseResponse<GuestGroupDTO>> GetById(Guid id);
    public Task<BaseResponse<GuestGroupDTO>> ConfirmAttendance(Guid id, IEnumerable<ConfirmAttendancePayload> payload);

}