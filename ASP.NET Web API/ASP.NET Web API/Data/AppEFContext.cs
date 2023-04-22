using ASP.NET_Web_API.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web_API.Data
{
    public class AppEFContext : DbContext
    {
        public AppEFContext(DbContextOptions<AppEFContext> options) : base(options)
        { }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
