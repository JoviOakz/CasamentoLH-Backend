using System.Net;

namespace CasamentoLH_Backend.Core.Middlewares.ErrorHandler.Errors;

public class InternalServerException : AppException
{
    public InternalServerException(string message, string? type = null) : base(message, HttpStatusCode.InternalServerError, type)
    { }

    public InternalServerException(string message, Exception inner, string? type = null) : base(message, inner, HttpStatusCode.InternalServerError, type)
    { }
}