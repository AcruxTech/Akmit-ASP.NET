using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.DataAccess.Models
{
    public class ClassRto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SecretCode { get; set; }

        public List<UserRto> Users { get; set; }
        public List<DayRto> Days { get; set; }
    }
}
