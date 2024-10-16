using System.Net;

namespace Contacts.Application.Exceptions
{
    public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}
