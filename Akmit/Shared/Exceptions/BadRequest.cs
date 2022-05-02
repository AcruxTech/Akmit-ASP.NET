using System;

namespace Akmit.Shared.Exceptions
{
    public class BadRequest : Exception
    {
        public BadRequest(string message) : base(message)
        {
        }
    }
}
