namespace CasamentoLH_Backend.Domain.Models;

public record GuestDTO(
    Guid Id,
    string Name,
    bool IsConfirmed,
    Guid GuestGroupId,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt
) : BaseDTO(Id, CreatedAt, UpdatedAt, DeletedAt)
{
    public static GuestDTO Map(Guest obj) => new(
        obj.Id,
        obj.Name,
        obj.IsConfirmed,
        obj.GuestGroup.Id,
        obj.CreatedAt,
        obj.UpdatedAt,
        obj.DeletedAt
    );
}
