using Microsoft.AspNetCore.Identity;

namespace ASP.NET_Web_API.Data.Entites.Identity
{
    public class RoleEntity : IdentityRole<int>
    {
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
