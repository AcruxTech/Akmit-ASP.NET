using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.DataAccess.Models
{
    public class LessonRto
    {
        public int Id { get; set; }
        public string Lesson { get; set; }
        public string Homework { get; set; }
        public int Cabinet { get; set; }
        
        public DayRto DayRto { get; set; }
        public int DayRtoId { get; set; }
    }
}
