namespace EfCorePostgre.Data
{
    using EfCorePostgre.Core;
    using EfCorePostgre.Data.Domain;

    using Microsoft.EntityFrameworkCore;

    /// <summary>The model builder extensions.</summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>The seed.</summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                        .HasData(
                            new Role
                                {
                                    Id          = 1,
                                    Name        = "Admin",
                                    Description = "Admin Role"
                                });

            modelBuilder.Entity<Permission>()
                        .HasData(
                            new Permission
                                {
                                    Id               = 1,
                                    PermissionTypeId = 1,
                                    Name             = "All Permission",
                                    Description      = "All Permission For Admin"
                                });

            var saltPassword = PasswordHelper.CreateSaltPassword();

            modelBuilder.Entity<User>()
                        .HasData(
                            new User
                                {
                                    Id           = 1,
                                    FirstName    = "Admin",
                                    LastName     = "Admin",
                                    Email        = "yasser021@gmail.com",
                                    Password     = PasswordHelper.EncodePassword("123456", saltPassword),
                                    PasswordSalt = saltPassword,
                                });

            modelBuilder.Entity<UserRole>()
                        .HasData(
                            new UserRole
                                {
                                    Id     = 1,
                                    UserId = 1,
                                    RoleId = 1,
                                });

            modelBuilder.Entity<UserPermission>()
                        .HasData(
                            new UserPermission
                                {
                                    Id           = 1,
                                    UserId       = 1,
                                    PermissionId = 1,
                                });
        }
    }
}