using CasamentoLH_Backend.Api.Payloads;
using CasamentoLH_Backend.Domain.Models;
using CasamentoLH_Backend.Domain.Repositories;
using CasamentoLH_Backend.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CasamentoLH_Backend.Core.Services;

public class GuestService(
    IBaseRepository<Guest> repository, IGuestGroupRepository guestGroupRepository
) : BaseService<Guest>(repository), IGuestService
{

    private readonly IBaseRepository<Guest> _repo = repository;
    private readonly IGuestGroupRepository _groupRepo = guestGroupRepository;

    public async Task<BaseResponse<IEnumerable<GuestGroupDTO>>> CreateManyGuests(IEnumerable<GuestGroupPayload> payload)
    {

        HashSet<Guid> groupIds = [];

        foreach (var group in payload)
        {
            var newGroup = new GuestGroup();
            await _groupRepo.AddAsync(newGroup);

            foreach (var guest in group.Guests)
            {
                var newGuest = new Guest()
                {
                    Name = guest.Name,
                    GuestGroup = newGroup
                };
                await _repo.AddAsync(newGuest);
            }

            groupIds.Add(newGroup.Id);
        }

        await _groupRepo.SaveAsync();
        await _repo.SaveAsync();

        return new BaseResponse<IEnumerable<GuestGroupDTO>>(
            _groupRepo.GetAll().Where(g => groupIds.Contains(g.Id)).Include(g => g.Guests).Select(GuestGroupDTO.Map),
            Message: "Many guests created successfully!",
            Mensagem: "Muitos convidados criados com sucesso!"
        );
    }

} 