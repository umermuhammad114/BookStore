using Microsoft.AspNetCore.Identity;

namespace BookStore.Data
{
    public class Role : IdentityRole<Guid>
    {
        public ICollection<Permission> Permissions { get; set; }
    }
}
