using System.ComponentModel.DataAnnotations;

namespace CasamentoLH_Backend.Api.Payloads;

public class ConfirmAttendancePayload
{
    [Required]
    public required Guid GuestId { get; set; }

    [Required]
    public required bool IsConfirmed { get; set; }
}