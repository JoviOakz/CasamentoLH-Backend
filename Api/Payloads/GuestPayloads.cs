using System.ComponentModel.DataAnnotations;

namespace CasamentoLH_Backend.Api.Payloads;

public class CreateGuestPayload
{
    [Required]
    [StringLength(255)]
    public required string Name { get; set; }
}

public class UpdateGuestPayload
{
    [StringLength(255)]
    public string? Name { get; set; }

    public bool? IsConfirmed { get; set; }
}