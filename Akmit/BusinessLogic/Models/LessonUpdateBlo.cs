using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Models
{
    public class LessonUpdateBlo
    {
        public int NewNumber { get; set; }
        public string NewLesson { get; set; }
        public string NewHomework { get; set; }
        public int NewCabinet { get; set; }
    }
}
