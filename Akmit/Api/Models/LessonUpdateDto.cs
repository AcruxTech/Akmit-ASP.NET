using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Api.Models
{
    public class LessonUpdateDto
    {
        public int ClassRtoId { get; set; }
        public string DayTitle { get; set; }
        public int Number { get; set; }
        public int NewNumber { get; set; }
        public string NewLesson { get; set; }
        public string NewHomework { get; set; }
        public int NewCabinet { get; set; }
    }
}
