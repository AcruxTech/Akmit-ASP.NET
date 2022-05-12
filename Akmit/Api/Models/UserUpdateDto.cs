using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Api.Models
{
    public class UserUpdateDto
    {
        public string Token { get; set; }
        public string newEmail { get; set; }
        public string newLogin { get; set; }
        public string newUrl { get; set; }
    }
}
