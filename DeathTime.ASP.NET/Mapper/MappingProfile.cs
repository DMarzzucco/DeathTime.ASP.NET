using AutoMapper;
using DeathTime.ASP.NET.User.DTOs;
using DeathTime.ASP.NET.User.Model;

namespace DeathTime.ASP.NET.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, UserModel>();
            CreateMap<UpdateUserDTO, UserModel>();
        }
    }
}
