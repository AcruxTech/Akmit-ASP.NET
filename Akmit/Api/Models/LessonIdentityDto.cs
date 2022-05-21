using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Api.Models
{
    public class LessonIdentityDto
    {
        public int ClassRtoId { get; set; }
        public string DayTitle { get; set; }
        public int Number { get; set; }
        public string Lesson { get; set; }
        public string Homework { get; set; }
        public int Cabinet { get; set; }
    }
}
