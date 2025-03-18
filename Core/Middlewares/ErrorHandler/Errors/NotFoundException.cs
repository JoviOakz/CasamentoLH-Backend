using System.Net;

namespace CasamentoLH_Backend.Core.Middlewares.ErrorHandler.Errors;

public class NotFoundException : AppException
{
    public NotFoundException(string message, string? type = null) : base(message, HttpStatusCode.NotFound, type)
    { }

    public NotFoundException(string message, Exception inner, string? type = null) : base(message, inner, HttpStatusCode.NotFound, type)
    { }
}