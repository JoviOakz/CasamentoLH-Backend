using CasamentoLH_Backend.Config;
using CasamentoLH_Backend.Domain.Models;
using CasamentoLH_Backend.Domain.Repositories;

namespace CasamentoLH_Backend.Core.Repositories;

public class GuestRepository(CasamentoLHContext context) : BaseRepository<Guest>(context), IGuestRepository
{ }