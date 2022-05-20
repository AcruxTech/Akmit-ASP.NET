using Akmit.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface ILessonService
    {
        Task<bool> Add(string token, LessonInformationBlo lessonInformationBlo);
        Task<LessonInformationBlo> Get(string token, string dayTitle, int number);
        Task<List<LessonInformationBlo>> GetDayLessons(string token, string dayTitle);
        // Task<List<LessonInformationBlo>> GetAll(string token);
        Task<bool> Update(string token, LessonUpdateBlo lessonUpdateBlo);
        Task<bool> Delete(string token, string dayTitle, int number);
    }
}
