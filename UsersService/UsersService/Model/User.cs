using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersService.Model
{
    /// <summary>
    /// Rappresenta un utente nel sistema.
    /// </summary>
    [Table("user")]
    public class User
    {
        /// <summary>
        /// Ottiene o imposta l'identificatore univoco dell'utente.
        /// </summary>
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome dell'utente.
        /// </summary>
        [Column("first_name"), Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Ottiene o imposta il cognome dell'utente.
        /// </summary>
        [Column("last_name"), Required]
        public string LastName { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome utente dell'utente.
        /// </summary>
        [Column("username"), Required]
        public string Username { get; set; }

        /// <summary>
        /// Ottiene o imposta l'identificatore dell'indirizzo associato all'utente, se presente.
        /// </summary>
        [Column("address_id")]
        public int? AddressId { get; set; }
    }
}
