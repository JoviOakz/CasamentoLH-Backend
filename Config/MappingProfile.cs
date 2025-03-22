using AutoMapper;
using CasamentoLH_Backend.Api.Payloads;
using CasamentoLH_Backend.Domain.Models;

namespace CasamentoLH_Backend.Config;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateGuestPayload, Guest>();
        CreateMap<CreateGuestGroupPayload, GuestGroup>();
    }
}