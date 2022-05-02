using System;

namespace Akmit.Shared.Exceptions
{
    public class Unauthorized : Exception
    {
        public Unauthorized(string message) : base(message)
        {
        }
    }
}
