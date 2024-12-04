using AutoMapper;
using DeathTime.ASP.NET.User.DTOs;
using DeathTime.ASP.NET.User.Model;
using DeathTime.ASP.NET.User.Repository.Interfaces;
using DeathTime.ASP.NET.User.Services.Interfaces;

namespace DeathTime.ASP.NET.User.Services
{
    public class UserServices : IUserServicesImpl
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserServices(IMapper mapper, IUserRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        //GetAll
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await this._repository.ToListAsync();
        }

        //Get by id
        public async Task<UserModel> GetById(int id)
        {
            var person = await this._repository.FindByIdAsync(id);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with {id}not found");
            }
            return person;
        }

        //Create a User
        public async Task<UserModel> CreateUser(CreateUserDTO user)
        {
            if (this._repository.ExistsByName(user.Name) )
            {
                throw new Exception("This Username already exists");
            }

            if (this._repository.ExistsByEmail(user.Email))
            {
                throw new Exception("This Email already exists");
            }

            var data = this._mapper.Map<UserModel>(user);

            await this._repository.AddChangeAsync(data);

            return data;
        }

        // Update a user by id
        public async Task<bool> UpdateUser(int id, UpdateUserDTO user)
        {
            var data = await this._repository.FindByIdAsync(id);
            if (data == null)
            {
                throw new KeyNotFoundException($"Person with {id}not found");
            }

            this._mapper.Map(user, data);

            await this._repository.UpdateAsync(data);
            return true;
        }

        //Delete User by id
        public async Task<bool> DeleteUser(int id)
        {
            var data = await this._repository.FindByIdAsync(id);
            if (data == null)
            {
                return false;
            }
            await this._repository.RemovceAsync(data);
            return true;
        }
    }
}
