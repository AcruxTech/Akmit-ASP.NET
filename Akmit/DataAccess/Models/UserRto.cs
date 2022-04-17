﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.DataAccess.Models
{
    public class UserRto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public int ClassRtoId { get; set; }
        public ClassRto ClassRto { get; set; }
    }
}