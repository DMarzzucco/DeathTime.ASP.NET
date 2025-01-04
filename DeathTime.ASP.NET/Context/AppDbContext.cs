using DeathTime.ASP.NET.Context.Configuration;
using DeathTime.ASP.NET.User.Model;
using Microsoft.EntityFrameworkCore;

namespace DeathTime.ASP.NET.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> UserModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new UserModelConfiguration());
            base.OnModelCreating(modelbuilder);
        }
    }
}
