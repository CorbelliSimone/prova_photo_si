using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressBooksService.Model
{
    /// <summary>
    /// Rappresenta un indirizzo nell'elenco degli indirizzi.
    /// </summary>
    [Table("address_book")]
    public class AddressBook
    {
        /// <summary>
        /// Ottiene o imposta l'ID dell'indirizzo.
        /// </summary>
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome della via dell'indirizzo.
        /// </summary>
        [Column("street_name"), Required]
        public string StreetName { get; set; }

        /// <summary>
        /// Ottiene o imposta il CAP dell'indirizzo.
        /// </summary>
        [Column("cap"), Required]
        public string Cap { get; set; }

        /// <summary>
        /// Ottiene o imposta il numero civico dell'indirizzo.
        /// </summary>
        [Column("street_number"), Required]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Ottiene o imposta l'ID della città a cui appartiene l'indirizzo.
        /// </summary>
        [Column("city_id"), Required]
        public int CityId { get; set; }

        /// <summary>
        /// Ottiene o imposta la città a cui appartiene l'indirizzo.
        /// </summary>
        public virtual City City { get; set; }
    }
}
