using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Akmit.Shared.Configurations
{
    public class AuthOptions
    {
        public const string ISSUER = "Akmit"; 
        public const string AUDIENCE = "Akmit";
        const string KEY = "mysupersecret_secretkey!123";   //!!!
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
