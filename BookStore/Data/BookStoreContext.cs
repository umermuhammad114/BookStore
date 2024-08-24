using BookStore.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data;

public class BookStoreContext(DbContextOptions<BookStoreContext> options)
    : IdentityDbContext<ApplicationUser, Role, Guid>(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<BookCategory> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new PermissionConfiguration());
        builder.ApplyConfiguration(new RolePermissionConfiguration());
        builder.ApplyConfiguration(new ApplicationUserConfiguration());

        SeedDataProvider.Seed(builder);
    }
}
