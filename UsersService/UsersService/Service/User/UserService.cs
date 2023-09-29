using AutoMapper;

using UsersService.Repository.User;
using UsersService.Service.User.Dto;
using UsersService.Service.User.Exceptionz;

namespace UsersService.Service.User
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;

        public UserService
        (
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            var alreadyExisstUser = await _userRepository.FindByUsernameAsync(userDto.Username) != null;
            if (alreadyExisstUser)
            {
                throw new UserException($"Utente con username {userDto.Username} gia' esistente");
            }

            var userToInsert = _mapper.Map<Model.User>(userDto);
            await _userRepository.AddAsync(userToInsert);
            userDto.Id = userToInsert.Id;
            return userDto;
        }

        public async Task DeleteAsync(int id)
        {
            var userToDelete = await _userRepository.GetAsync(id);
            if (userToDelete == null)
            {
                throw new UserException($"Utente {id} non esistente");
            }

            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAsync()
        {
            var user = await _userRepository.GetAsync();
            return _mapper.Map<List<UserDto>>(user);
        }

        public async Task<int> UpdateAddressAsync(int id, int addressId)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                throw new UserException($"Utente non esistente {id}");
            }

            user.AddressId = addressId;
            return await _userRepository.SaveAsync();
        }

        public async Task<int> UpdateAsync(int id, UserDto userDto)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                throw new UserException($"Utente con id {id} non esistente");
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName ;
            user.Username = userDto.Username;

            return await _userRepository.SaveAsync();
        }
    }
}
