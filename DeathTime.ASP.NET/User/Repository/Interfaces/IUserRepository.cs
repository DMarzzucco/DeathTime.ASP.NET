using DeathTime.ASP.NET.User.Model;

namespace DeathTime.ASP.NET.User.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task SaveChangeAsync();

        Task<UserModel?> FindByIdAsync(int id);

        Task<IEnumerable<UserModel>> ToListAsync();

        bool ExistsByEmail(string email);

        bool ExistsByName(string name);

        Task<UserModel?> FindAsync();

        Task RemovceAsync(UserModel user);

        Task AddChangeAsync(UserModel data);

        Task UpdateAsync(UserModel user);
    }
}
