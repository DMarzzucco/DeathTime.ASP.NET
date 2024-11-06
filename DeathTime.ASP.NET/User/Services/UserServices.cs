using AutoMapper;
using DeathTime.ASP.NET.Context;
using DeathTime.ASP.NET.User.DTOs;
using DeathTime.ASP.NET.User.Model;
using DeathTime.ASP.NET.User.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeathTime.ASP.NET.User.Services
{
    public class UserServices : IUserServicesImpl
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserServices(
            AppDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
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
            if (await this._context.UserModel.AnyAsync(u => u.Name == user.Name))
            {
                throw new Exception("This Username already exists");
            }

            if (await this._context.UserModel.AnyAsync(u => u.Email == user.Email))
            {
                throw new Exception("This Email already exists");
            }

            var data = this._mapper.Map<UserModel>(user);

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
                throw new KeyNotFoundException($"Person with {id}not found");
            }

            this._mapper.Map(user, data);

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
    }
}
