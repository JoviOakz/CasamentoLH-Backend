using System.ComponentModel.DataAnnotations;

namespace CasamentoLH_Backend.Api.Payloads;

public class GuestGroupPayload
{
    [Required]
    public required IEnumerable<GuestPayload> Guests { get; set; }
}