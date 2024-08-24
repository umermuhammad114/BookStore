using BookStore.Data;

namespace BookStore.Authentication
{
    public interface IJwtProvider
    {
        public string Generate(ApplicationUser user, List<Permission> permissions);

    }
}
