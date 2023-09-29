using UsersService.Model;

namespace UsersService.Repository.User
{
    public interface IUserRepository : IGenericRepository<Model.User>
    {
        Task<Model.User> FindByUsernameAsync(string username);
    }
}
