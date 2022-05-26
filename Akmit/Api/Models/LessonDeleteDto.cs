using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Api.Models
{
    public class LessonDeleteDto
    {
        public int ClassRtoId { get; set; }
        public string DayTitle{ get; set; }
        public int Number { get; set; }
    }
}
