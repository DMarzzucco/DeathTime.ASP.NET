using DeathTime.ASP.NET.Context;
using DeathTime.ASP.NET.User.Model;
using DeathTime.ASP.NET.User.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeathTime.ASP.NET.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task AddChangeAsync(UserModel data)
        {
            this._context.Add(data);
            await this._context.SaveChangesAsync();
        }

        public bool ExistsByEmail(string email)
        {
            return this._context.UserModel.Any(u => u.Email == email);
        }

        public bool ExistsByName(string name)
        {
            return this._context.UserModel.Any(u => u.Name == name);
        }

        public async Task<UserModel?> FindAsync()
        {
            return await this._context.UserModel.FindAsync();
        }

        public async Task<UserModel?> FindByIdAsync(int id)
        {
            return await this._context.UserModel.FindAsync(id);
        }

        public async Task RemovceAsync(UserModel user)
        {
            this._context.UserModel.Remove(user);
            await this._context.SaveChangesAsync();
        }

        public async Task SaveChangeAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserModel>> ToListAsync()
        {
            return await this._context.UserModel.ToListAsync();
        }

        public async Task UpdateAsync(UserModel user)
        {
            this._context.Entry(user).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
    }
}
