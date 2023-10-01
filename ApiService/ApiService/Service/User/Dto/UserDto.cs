namespace ApiService.Service.User.Dto
{
    /// <summary>
    /// Rappresenta un utente loggato.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Ottiene o imposta l'ID dell'utente.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome utente dell'utente.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome dell'utente.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Ottiene o imposta il cognome dell'utente.
        /// </summary>
        public string LastName { get; set; }
    }
}
