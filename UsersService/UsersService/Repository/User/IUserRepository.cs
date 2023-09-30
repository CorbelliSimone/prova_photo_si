namespace UsersService.Repository.User
{
    /// <summary>
    /// Interfaccia per il repository degli utenti.
    /// </summary>
    public interface IUserRepository : IGenericRepository<Model.User>
    {
        /// <summary>
        /// Trova un utente per nome utente.
        /// </summary>
        /// <param name="username">Nome utente dell'utente da cercare.</param>
        /// <returns>Task asincrono che restituisce l'utente trovato, null se non trovato.</returns>
        Task<Model.User> FindByUsernameAsync(string username);
    }
}
