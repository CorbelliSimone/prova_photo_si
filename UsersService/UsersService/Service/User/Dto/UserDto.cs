namespace UsersService.Service.User.Dto
{
    /// <summary>
    /// Classe che rappresenta il modello di dati per un utente (DTO).
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Ottiene o imposta l'identificatore dell'utente.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome dell'utente.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Ottiene o imposta il cognome dell'utente.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome utente dell'utente.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Ottiene o imposta l'identificatore dell'indirizzo associato all'utente.
        /// </summary>
        public int? AddressId { get; set; }
    }
}
