using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Shared.Exceptions
{
    public class NoContent : Exception
    {
        public NoContent(string message) : base(message)
        {
        }
    }
}
