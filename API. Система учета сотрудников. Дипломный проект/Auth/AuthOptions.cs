using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BisnesManager.WebAPI.Diplom.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "DiplomaAuthServer"; // издатель токена
        public const string AUDIENCE = "DiplomaAuthClient"; // потребитель токена
        const string KEY = "mysupersupersecret_secretkey!456";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
