namespace CasamentoLH_Backend.Domain.Models;

public record GuestGroupDTO(
    Guid Id,
    IEnumerable<GuestDTO> Guests,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt
) : BaseDTO(Id, CreatedAt, UpdatedAt, DeletedAt)
{
    public static GuestGroupDTO Map(GuestGroup obj) => new(
        obj.Id,
        obj.Guests.Select(GuestDTO.Map),
        obj.CreatedAt,
        obj.UpdatedAt,
        obj.DeletedAt
    );
}
