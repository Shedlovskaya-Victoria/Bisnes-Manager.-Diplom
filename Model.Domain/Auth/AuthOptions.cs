using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BisnesManager.WebAPI.Diplom.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "http://localhost:7285/"; // издатель токена
        public const string AUDIENCE = "http://localhost:7285/"; // потребитель токена
        const string KEY = "mybungostraydogssupersupersecret_secretkey!456";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
