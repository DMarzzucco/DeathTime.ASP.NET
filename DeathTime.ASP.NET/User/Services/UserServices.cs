using DeathTime.ASP.NET.Context;
using DeathTime.ASP.NET.User.DTOs;
using DeathTime.ASP.NET.User.Interfaces;
using DeathTime.ASP.NET.User.Model;
using Microsoft.EntityFrameworkCore;

namespace DeathTime.ASP.NET.User.Services
{
    public class UserServices : IUserServicesImpl
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        //GetAll
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _context.UserModel.ToListAsync();
        }

        //Get by id
        public async Task<UserModel> GetById(int id)
        {
            var person = await _context.UserModel.FindAsync(id);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with {id}not found");
            }
            return person;
        }

        //Create a User
        public async Task<UserModel> CreateUser(CreateUserDTO user)
        {
            var data = new UserModel
            {
                Name = user.Name,
                Age = user.Age,
                Email = user.Email
            };
            _context.UserModel.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        // Update a user by id
        public async Task<bool> UpdateUser(int id, UpdateUserDTO user)
        {
            var data = await this._context.UserModel.FindAsync(id);
            if (data == null)
            {
                return false;
            }

            CopyProperties(user, data);

            _context.Entry(data).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
            return true;
        }

        //Delete User by id
        public async Task<bool> DeleteUser(int id)
        {
            var data = await this._context.UserModel.FindAsync(id);
            if (data == null)
            {
                return false;
            }
            this._context.UserModel.Remove(data);
            await this._context.SaveChangesAsync();
            return true;
        }

        public static void CopyProperties<TSource, TTarget>(TSource source, TTarget target)
        {
            var sourceProperties = typeof(TSource).GetProperties();
            var targetProperties = typeof(TTarget).GetProperties();

            foreach (var property in sourceProperties)
            {
                var targetProperty = targetProperties.FirstOrDefault(
                    p => p.Name == property.Name && p.PropertyType == property.PropertyType
                    );

                if (targetProperty != null && targetProperty.CanWrite)
                {
                    targetProperty.SetValue(target, property.GetValue(source));
                }
            }
        }
    }
}
