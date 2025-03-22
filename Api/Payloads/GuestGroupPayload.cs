using System.ComponentModel.DataAnnotations;

namespace CasamentoLH_Backend.Api.Payloads;

public class CreateGuestGroupPayload
{
    [Required]
    public required IEnumerable<CreateGuestPayload> Guests { get; set; }
}