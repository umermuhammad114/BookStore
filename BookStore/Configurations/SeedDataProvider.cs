using BookStore.Data;
using BookStore.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Configurations
{
    public static class SeedDataProvider
    {
        private static readonly List<Role> _roles = new();
        private static readonly List<Permission> _permissions = new();

        static SeedDataProvider()
        {
            _roles.Add(new Role()
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Name = Roles.Librarian.ToString()
            });

            _roles.Add(new Role()
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
                Name = Roles.Teacher.ToString()
            });

            _roles.Add(new Role()
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
                Name = Roles.Student.ToString()
            });

            _permissions.Add(new Permission()
            {
                Id = new Guid("44444444-4444-4444-4444-444444444444"),
                Name = Permissions.AddBook.ToString()
            });

            _permissions.Add(new Permission()
            {
                Id = new Guid("55555555-5555-5555-5555-555555555555"),
                Name = Permissions.DeleteBook.ToString()
            });

            _permissions.Add(new Permission()
            {
                Id = new Guid("66666666-6666-6666-6666-666666666666"),
                Name = Permissions.GetBooks.ToString()
            });

        }

        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .HasData(_roles);

            builder.Entity<Permission>()
                .HasData(_permissions);

            builder.Entity<RolePermission>()
                .HasData(
                    Create(Roles.Librarian, Permissions.GetBooks),
                    Create(Roles.Librarian, Permissions.DeleteBook),
                    Create(Roles.Librarian, Permissions.AddBook),
                    Create(Roles.Student, Permissions.GetBooks),
                    Create(Roles.Teacher, Permissions.GetBooks));
        }

        private static RolePermission Create(Roles role, Permissions permission)
        {
            return new RolePermission
            {
                RoleId = _roles.First(a => a.Name!.Equals(role.ToString()))!.Id,
                PermissionId = _permissions.First(a => a.Name.Equals(permission.ToString()))!.Id
            };
        }
    }
}
