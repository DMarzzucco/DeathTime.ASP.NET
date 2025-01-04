using DeathTime.ASP.NET.User.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeathTime.ASP.NET.Context.Configuration
{
    public class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(row => row.Id);
            builder.Property(row => row.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(row => row.Name).IsUnicode();
            builder.Property(row => row.Email).IsUnicode();
        }
    }
}
