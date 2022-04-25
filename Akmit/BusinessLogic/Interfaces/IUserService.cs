using Akmit.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<string> Register(UserIdentityBlo userIdentityBlo);
        Task<string> Auth(UserIdentityBlo userIdentityBlo);
        Task<UserInformationBlo> GetByToken(string token);
        Task<UserInformationShortBlo> GetById(int id);
        Task<UserInformationBlo> Change(string token, UserUpdateBlo userUpdateBlo);
        Task<UserInformationBlo> ChangePass(string token, string pass, string newPass);
        Task<bool> Delete(string token, string pass);
        Task<bool> IsExist(string email, string login);
    }
}
