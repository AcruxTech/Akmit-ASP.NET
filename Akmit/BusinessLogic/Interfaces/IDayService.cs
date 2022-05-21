using Akmit.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface IDayService
    {
        Task<bool> Add(string token, string title, string pavilion);
        Task<List<DayInformationBlo>> GetAll(int classRtoId);
        Task<bool> Update(string token, string title, string newTitle, string newPavilion);
        Task<bool> Delete(int classRtoId, string title);
    }
}
