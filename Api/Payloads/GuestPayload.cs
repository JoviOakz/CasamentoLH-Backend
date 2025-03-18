using System.ComponentModel.DataAnnotations;

namespace CasamentoLH_Backend.Api.Payloads;

public class GuestPayload
{
    [Required]
    [StringLength(255)]
    public required string Name { get; set; }
}