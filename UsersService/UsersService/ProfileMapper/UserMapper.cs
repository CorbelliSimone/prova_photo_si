using AutoMapper;

using UsersService.Model;
using UsersService.Service.User.Dto;

namespace UsersService.ProfileMapper
{
    /// <summary>
    /// Mapper per la conversione tra la classe User e UserDto.
    /// </summary>
    public class UserMapper : Profile
    {
        /// <summary>
        /// Crea un nuovo mapper per User e UserDto.
        /// </summary>
        public UserMapper()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}
