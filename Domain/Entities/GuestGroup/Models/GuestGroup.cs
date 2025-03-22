namespace CasamentoLH_Backend.Domain.Models;

public class GuestGroup : BaseEntity
{
    public ICollection<Guest> Guests { get; set; } = [];

    public override BaseDTO DTO => GuestGroupDTO.Map(this);
}