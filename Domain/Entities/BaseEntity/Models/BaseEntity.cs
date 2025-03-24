namespace CasamentoLH_Backend.Domain.Models;

public abstract class BaseEntity
{
    public Guid Id = Guid.NewGuid();
    public readonly DateTime CreatedAt = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public DateTime? DeletedAt { get; set; } = null;

    public virtual BaseDTO DTO => BaseDTO.Map(this);

}