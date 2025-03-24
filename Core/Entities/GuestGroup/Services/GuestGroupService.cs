using AutoMapper;
using CasamentoLH_Backend.Api.Payloads;
using CasamentoLH_Backend.Core.Middlewares.ErrorHandler.Errors;
using CasamentoLH_Backend.Domain.Models;
using CasamentoLH_Backend.Domain.Repositories;
using CasamentoLH_Backend.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CasamentoLH_Backend.Core.Services;

public class GuestGroupService(
    IBaseRepository<GuestGroup> repository, IGuestRepository guestRepository, IMapper mapper
) : BaseService<GuestGroup>(repository, mapper), IGuestGroupService
{

    private readonly IBaseRepository<GuestGroup> _repo = repository;
    private readonly IGuestRepository _guestRepo = guestRepository;

    public async Task<BaseResponse<GuestGroupDTO>> GetById(Guid id)
    {
        var group = await _repo.GetAll()
            .Include(g => g.Guests)
            .SingleOrDefaultAsync(g => g.Id == id)
            ?? throw new NotFoundException($"Guest group with ID {id} not found.");

        return new BaseResponse<GuestGroupDTO>(
            group.DTO,
            "Guest Group found!",
            "Grupo de convidados encontrado!"
        );
    }

    public async Task<BaseResponse<GuestGroupDTO>> ConfirmAttendance(Guid id, IEnumerable<ConfirmAttendancePayload> payload)
    {
        var group = await _repo.GetAll()
            .Include(g => g.Guests)
            .SingleOrDefaultAsync(g => g.Id == id)
            ?? throw new NotFoundException($"Guest group with ID {id} not found.");

        var groupGuests = group.Guests.ToDictionary(g => g.Id, g => g);

        foreach (var guestPayload in payload)
        {
            if (!groupGuests.TryGetValue(guestPayload.GuestId, out Guest? guest)) throw new NotFoundException($"Guest with ID {guestPayload.GuestId} not found.");

            guest.IsConfirmed = guestPayload.IsConfirmed;
            await _guestRepo.UpdateAsync(guest);
        }

        await _guestRepo.SaveAsync();
        group.Guests = [.. groupGuests.Values];

        return new BaseResponse<GuestGroupDTO>(
            group.DTO,
            "Guest group updated successfully!",
            "Grupo de convidados editado com sucesso!"
        );
    }
}