namespace AddressBooksService.Service.AddressBook.Dto
{
    /// <summary>
    /// Rappresenta i dati di un libro degli indirizzi.
    /// </summary>
    public class AddressBookDto
    {
        /// <summary>
        /// Ottiene o imposta l'ID del libro degli indirizzi.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome della strada.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Ottiene o imposta il codice postale.
        /// </summary>
        public string Cap { get; set; }

        /// <summary>
        /// Ottiene o imposta il numero civico.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Ottiene o imposta l'ID della città associata a questo libro degli indirizzi.
        /// </summary>
        public int CityId { get; set; }
    }
}
