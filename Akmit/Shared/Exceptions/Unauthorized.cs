using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Shared.Exceptions
{
    public class Unauthorized : Exception
    {
        public Unauthorized(string message) : base(message)
        {
        }
    }
}
