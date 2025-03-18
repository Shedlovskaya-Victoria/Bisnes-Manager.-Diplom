using Microsoft.AspNetCore.Http;

namespace BisnesManager.WebAPI.Diplom.Auth
{
    public class HttpContextInfo
    {
        public static int GetUserID(HttpContext httpContext)
        {
            var claim = httpContext.User.Claims
                            .FirstOrDefault(s => s.Type == "ID");
            if (claim == null)
                throw new Exception("Требуется авторизация");
            int idUser = int.Parse(claim.Value);
            return idUser;
        }
    }
}
