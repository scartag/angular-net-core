using System;
using Contacts.Application.Exceptions;

namespace Contacts.Infrastructure.Exceptions.Definition
{
    public interface IExceptionCompositionRoot
    {
        ExceptionResponse Map(Exception exception);
    }
}
