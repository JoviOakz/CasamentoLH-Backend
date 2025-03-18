using System.Net;
using Microsoft.OpenApi.Extensions;

namespace CasamentoLH_Backend.Core.Middlewares.ErrorHandler
{
    public class AppException : Exception
    {
        public readonly int Status;
        public readonly string Title;
        public readonly string? Type;

        public AppException(string message, HttpStatusCode httpStatus, string? type = null) : base(message)
        {
            Status = (int)httpStatus;
            Title = httpStatus.GetDisplayName();
            Type = type;
        }

        public AppException(string message, Exception inner, HttpStatusCode httpStatus, string? type = null) : base(message, inner)
        {
            Status = (int)httpStatus;
            Title = httpStatus.GetDisplayName();
            Type = type;
        }
    }
}
