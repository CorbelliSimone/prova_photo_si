using AutoMapper;

using UsersService.Repository.User;
using UsersService.Service.User.Dto;
using UsersService.Service.User.Exceptionz;

namespace UsersService.Service.User
{
    /// <summary>
    /// Implementa il servizio degli utenti.
    /// </summary>
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;

        /// <summary>
        /// Crea un'istanza del servizio degli utenti.
        /// </summary>
        /// <param name="userRepository">Il repository degli utenti.</param>
        /// <param name="mapper">L'oggetto di mapping.</param>
        public UserService
        (
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Aggiunge un nuovo utente.
        /// </summary>
        /// <param name="userDto">I dettagli dell'utente da aggiungere.</param>
        /// <returns>I dettagli dell'utente aggiunto.</returns>
        /// <exception cref="UserException">Eccezione lanciata se l'utente con lo stesso username esiste già.</exception>
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

        /// <summary>
        /// Elimina un utente in base all'ID specificato.
        /// </summary>
        /// <param name="id">L'ID dell'utente da eliminare.</param>
        /// <exception cref="UserException">Eccezione lanciata se l'utente con l'ID specificato non esiste.</exception>
        public async Task DeleteAsync(int id)
        {
            var userToDelete = await _userRepository.GetAsync(id);
            if (userToDelete == null)
            {
                throw new UserException($"Utente {id} non esistente");
            }

            await _userRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Ottiene un utente in base all'ID specificato.
        /// </summary>
        /// <param name="id">L'ID dell'utente da ottenere.</param>
        /// <returns>
        /// Restituisce un oggetto UserDto che rappresenta l'utente corrispondente all'ID specificato,
        /// oppure null se l'utente non esiste.
        /// </returns>
        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// Ottiene tutti gli utenti presenti nel sistema.
        /// </summary>
        /// <returns>
        /// Restituisce una lista di oggetti UserDto che rappresentano tutti gli utenti presenti nel sistema.
        /// </returns>
        public async Task<List<UserDto>> GetAsync()
        {
            var user = await _userRepository.GetAsync();
            return _mapper.Map<List<UserDto>>(user);
        }

        /// <summary>
        /// Aggiorna le informazioni di un utente nel sistema.
        /// </summary>
        /// <param name="id">L'identificatore univoco dell'utente da aggiornare.</param>
        /// <param name="userDto">Oggetto contenente le informazioni aggiornate dell'utente.</param>
        /// <returns>
        /// Restituisce un intero che rappresenta lo stato dell'aggiornamento delle informazioni dell'utente.
        /// </returns>
        /// <exception cref="UserException">Eccezione generata se l'utente non è presente nel sistema.</exception>
        public async Task<int> UpdateAsync(int id, UserDto userDto)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                throw new UserException($"Utente con id {id} non esistente");
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Username = userDto.Username;

            return await _userRepository.SaveAsync();
        }
    }
}
