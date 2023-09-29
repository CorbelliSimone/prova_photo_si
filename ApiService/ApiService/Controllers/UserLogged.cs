namespace ApiService.Controllers
{
    public class UserLoggedHandler
    {
        public UserLogged UserLogged { get; private set; }

        public void SetUserLogged(UserLogged userLogged)
        {
            UserLogged = userLogged;
        }
    }

    public class UserLogged
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int? AddressId { get; set; }
    }
}
