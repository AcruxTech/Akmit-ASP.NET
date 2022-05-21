using Akmit.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        /* swagger - https://coderjony.com/blogs/adding-swagger-to-aspnet-core-31-web-api/ */
        /// <summary>
        /// Регистрирует нового пользователя по логину, почте и паролю 
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Возвращает токен созданного пользователя</returns>
        Task<string> Register(string login, string email, string password);
        Task<string> Auth(string identity, string password);
        Task<UserInformationBlo> GetByToken(string token);
        Task<UserInformationShortBlo> GetById(int id);
        Task<List<UserInformationShortBlo>> GetByClassId(int id);
        Task<UserInformationBlo> Change(string token, string newLogin, string newEmail, string newUrl);
        Task<UserInformationBlo> ChangePass(string token, string pass, string newPass);
        Task<bool> Delete(string token, string pass);
        Task<bool> IsExist(string email, string login);
    }
}
