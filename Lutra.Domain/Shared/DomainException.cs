using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Domain.Shared
{
    public class DomainException : Exception
    {
        public DomainException(): base() { }
        public DomainException(string message): base(message) { }
        public DomainException(string message, Exception innerException): base(message, innerException) { }
    }
}
