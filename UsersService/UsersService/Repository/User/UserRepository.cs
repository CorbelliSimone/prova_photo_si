using Microsoft.EntityFrameworkCore;

using UsersService.Model;

namespace UsersService.Repository.User
{
    /// <summary>
    /// Implementazione del repository per gli utenti.
    /// </summary>
    public class UserRepository : GenericRepository<Model.User>, IUserRepository
    {
        /// <summary>
        /// Crea una nuova istanza di UserRepository.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public UserRepository(Context context) : base(context)
        {
        }

        /// <summary>
        /// Trova un utente per nome utente.
        /// </summary>
        /// <param name="username">Nome utente dell'utente da cercare.</param>
        /// <returns>Task asincrono che restituisce l'utente trovato, null se non trovato.</returns>
        public Task<Model.User> FindByUsernameAsync(string username) => _context.Users.SingleOrDefaultAsync(x => x.Username == username);
    }
}
