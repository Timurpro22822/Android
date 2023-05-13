using ASP.NET_Web_API.Data.Entites.Identity;

namespace ASP.NET_Web_API.Abstract
{
    public interface IJwtTokenService
    {
        Task<string> CreateToken(UserEntity user);

    }
}
