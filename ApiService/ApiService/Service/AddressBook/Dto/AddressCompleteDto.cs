namespace ApiService.Service.AddressBook.Dto
{
    /// <summary>
    /// Rappresenta i dettagli completi di un indirizzo.
    /// </summary>
    public class AddressCompleteDto
    {
        /// <summary>
        /// Ottiene o imposta il nome della via.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Ottiene o imposta il codice di avviamento postale (CAP).
        /// </summary>
        public string Cap { get; set; }

        /// <summary>
        /// Ottiene o imposta il numero civico.
        /// </summary>
        public string StreetNumber { get; set; }
    }
}
