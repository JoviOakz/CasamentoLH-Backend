namespace CasamentoLH_Backend.Domain.Models;

public class Guest : BaseEntity
{
    public required string Name { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public required GuestGroup GuestGroup { get; set; }
}