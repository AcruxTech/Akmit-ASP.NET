using System.Collections.Generic;

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
