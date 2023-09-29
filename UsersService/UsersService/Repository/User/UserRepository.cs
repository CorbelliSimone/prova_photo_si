using Microsoft.EntityFrameworkCore;

using UsersService.Model;

namespace UsersService.Repository.User
{
    public class UserRepository : GenericRepository<Model.User>, IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }

        public Task<Model.User> FindByUsernameAsync(string username) => _context.Users.SingleOrDefaultAsync(x => x.Username == username);
    }
}
