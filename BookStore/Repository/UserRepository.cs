using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class UserRepository(BookStoreContext _context) : IUserRepository
    {
        private readonly BookStoreContext context = _context;

        public async Task<List<Permission>> GetUserPermissions(string username)
        {
            var user = await this.context.Users
                .Include(a => a.Roles)
                .ThenInclude(a => a.Permissions)
                .FirstOrDefaultAsync(a => a.UserName!.Equals(username));

            if (user == null)
            {
                return new List<Permission>();
            }

            return user.Roles.SelectMany(a => a.Permissions).ToList();
        }
    }
}
