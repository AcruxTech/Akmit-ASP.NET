namespace Akmit.DataAccess.Models
{
    public class LessonRto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Lesson { get; set; }
        public string Homework { get; set; }
        public int Cabinet { get; set; }
        
        public int DayRtoId { get; set; }
    }
}
