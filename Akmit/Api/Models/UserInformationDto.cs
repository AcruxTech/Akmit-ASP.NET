using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Api.Models
{
    public class UserInformationDto
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public int ClassRtoId { get; set; }
    }
}
