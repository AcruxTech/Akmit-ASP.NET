using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akmit.Shared.Configurations
{
    public class AuthOptions
    {
        public const string ISSUER = "Akmit"; 
        public const string AUDIENCE = "Akmit";
        const string KEY = "mysupersecret_secretkey!123";  // поменять!!!!!!!
        public const int LIFETIME = 1; // убрать
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
