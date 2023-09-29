using AutoMapper;

using UsersService.Model;
using UsersService.Service.User.Dto;

namespace UsersService.ProfileMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>()
                .ReverseMap()
                ;
        }
    }
}
