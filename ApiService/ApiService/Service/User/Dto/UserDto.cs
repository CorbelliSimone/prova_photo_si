namespace ApiService.Service.User.Dto
{
    // Simula un utente loggato
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int? AddressId { get; set; }
    }
}
