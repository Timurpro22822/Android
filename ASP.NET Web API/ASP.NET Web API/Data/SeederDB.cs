using ASP.NET_Web_API.constants;
using ASP.NET_Web_API.Data.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web_API.Data
{
    public static class SeederDB
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();
                context.Database.Migrate();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<RoleEntity>>();
            
                if(!context.Roles.Any())
                {
                    RoleEntity admin = new RoleEntity()
                    {
                        Name = Roles.Admin
                    };
                    
                    RoleEntity user = new RoleEntity()
                    {
                        Name = Roles.User
                    };
                    var result = roleManager.CreateAsync(admin).Result;
                    result = roleManager.CreateAsync(user).Result;

                }
                if(!context.Users.Any())
                {
                    UserEntity user
                        = new UserEntity()
                        {
                            FirstName = "Ivan",
                            LastName = "Kichovskiy",
                            Email = "ivankichovskiy@gmail.com",
                            UserName = "ivankichovskiy@gmail.com"
                        };
                    var result = userManager.CreateAsync(user, "123456").Result;
                    if(result.Succeeded)
                    {
                        result = userManager.AddToRoleAsync(user, Roles.Admin).Result;
                    }
                }
            }
        }
    }
}
