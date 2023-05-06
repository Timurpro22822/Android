using Microsoft.AspNetCore.Identity;

namespace ASP.NET_Web_API.Data.Entites.Identity
{
    public class UserRoleEntity : IdentityUserRole<int>
    {
        public virtual UserEntity User { get; set; }
        public virtual RoleEntity Role { get; set; }
    }
}
