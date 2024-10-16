using System;

namespace Contacts.Infrastructure.Exceptions.Definition
{
    public abstract class InfrastructureException : Exception
    {
        protected InfrastructureException(string message)
            : base(message) { }
    }
}
