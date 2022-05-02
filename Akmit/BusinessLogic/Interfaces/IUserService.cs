using Akmit.BusinessLogic.Models;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<string> Register(string login, string email, string password);
        Task<string> Auth(string identity, string password);
        Task<UserInformationBlo> GetByToken(string token);
        Task<UserInformationShortBlo> GetById(int id);
        Task<UserInformationBlo> Change(string token, string newLogin, string newEmail);
        Task<UserInformationBlo> ChangePass(string token, string pass, string newPass);
        Task<bool> Delete(string token, string pass);
        Task<bool> IsExist(string email, string login);
    }
}
