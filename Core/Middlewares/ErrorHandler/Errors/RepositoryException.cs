using System.Net;

namespace CasamentoLH_Backend.Core.Middlewares.ErrorHandler.Errors;

public class RepositoryException : AppException
{
    public RepositoryException(string message, string? type = null) : base(message, HttpStatusCode.InternalServerError, type)
    { }

    public RepositoryException(string message, Exception inner, string? type = null) : base(message, inner, HttpStatusCode.InternalServerError, type)
    { }
}