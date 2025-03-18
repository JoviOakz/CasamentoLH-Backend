namespace CasamentoLH_Backend.Domain.Models;

public record BaseDTO(
    Guid Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt
)
{
    public static BaseDTO Map(BaseEntity obj) => new(
        obj.Id,
        obj.CreatedAt,
        obj.UpdatedAt,
        obj.DeletedAt
    );
}

