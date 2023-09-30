using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBooksService.Model
{
    /// <summary>
    /// Rappresenta una città.
    /// </summary>
    [Table("city")]
    public class City
    {
        /// <summary>
        /// Ottiene o imposta l'ID della città.
        /// </summary>
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome della città.
        /// </summary>
        [Column("name"), Required]
        public string Name { get; set; }

        /// <summary>
        /// Ottiene o imposta il codice catastale della città.
        /// </summary>
        [Column("cadastral_code"), Required]
        public string CadastralCode { get; set; }

        /// <summary>
        /// Ottiene o imposta l'ID del Paese a cui appartiene la città.
        /// </summary>
        [Column("country_id"), Required]
        public int CountryId { get; set; }

        /// <summary>
        /// Ottiene o imposta la collezione degli indirizzi appartenenti alla città.
        /// </summary>
        public virtual ICollection<AddressBook> AddressBooks { get; set; }

        /// <summary>
        /// Ottiene o imposta il Paese a cui appartiene la città.
        /// </summary>
        public virtual Country Country { get; set; }
    }
}
