namespace CasamentoLH_Backend.Domain.Models;

public record BaseResponse<T>(
    T Data,
    string? Message = null,
    string? Mensagem = null
);