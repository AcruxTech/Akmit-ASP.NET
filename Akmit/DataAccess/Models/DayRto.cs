﻿using System.Collections.Generic;

namespace Akmit.DataAccess.Models
{
    public class DayRto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Pavilion { get; set; }

        public List<LessonRto> Lessons { get; set; }
        public int ClassRtoId { get; set; }
        public ClassRto ClassRto { get; set; }
    }
}
