using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Api.Models
{
    public class UserUpdateDto
    {
        public string Token { get; set; }
        public string NewEmail { get; set; }
        public string NewLogin { get; set; }
        public string NewUrl { get; set; }
    }
}
