using DeathTime.ASP.NET.User.DTOs;
using DeathTime.ASP.NET.User.Model;

namespace DeathTime.ASP.NET.User.Services.Interfaces
{
    public interface IUserServicesImpl
    {
        Task<IEnumerable<UserModel>> GetAll();

        Task<UserModel> GetById(int id);

        Task<UserModel> CreateUser(CreateUserDTO user);

        Task<UserModel> UpdateUser(int id, UpdateUserDTO user);

        Task DeleteUser(int id);
    }
}
