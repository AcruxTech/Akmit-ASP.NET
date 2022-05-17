using Akmit.BusinessLogic.Models;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface IClassService
    {
        Task<ClassInformationBlo> Get(int id);
        Task<ClassInformationBlo> Create(string token, string title); 
        Task<bool> Join(string token, string title, int secretCode);
        Task<bool> Leave(string token);
        Task<int> RefreshCode(string token);
    }
}
