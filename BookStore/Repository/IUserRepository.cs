using BookStore.Data;

namespace BookStore.Repository
{
    public interface IUserRepository
    {
        Task<List<Permission>> GetUserPermissions(string username);
    }
}
