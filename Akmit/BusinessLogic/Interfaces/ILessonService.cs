using Akmit.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface ILessonService
    {
        Task<bool> Add(int classRtoId, string dayTitle, LessonInformationBlo lessonInformationBlo);
        Task<List<LessonInformationBlo>> GetDayLessons(int classRtoId, string dayTitle);
        Task<bool> Update(int classRtoId, string dayTitle, int number, LessonUpdateBlo lessonUpdateBlo);
        Task<bool> Delete(int classRtoId, string dayTitle, int number);
    }
}
