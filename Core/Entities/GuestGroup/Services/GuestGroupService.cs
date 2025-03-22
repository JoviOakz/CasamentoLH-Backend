using AutoMapper;
using CasamentoLH_Backend.Domain.Models;
using CasamentoLH_Backend.Domain.Repositories;
using CasamentoLH_Backend.Domain.Services;

namespace CasamentoLH_Backend.Core.Services;

public class GuestGroupService(
    IBaseRepository<GuestGroup> repository, IMapper mapper
) : BaseService<GuestGroup>(repository, mapper), IGuestGroupService
{

    private readonly IBaseRepository<GuestGroup> _repo = repository;
} 