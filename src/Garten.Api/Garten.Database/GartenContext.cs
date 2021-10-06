using Garten.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Garten.Database
{
    public class GartenContext : DbContext
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="options"></param>
        public GartenContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Administrators
        /// </summary>
        public DbSet<Admin> Admins { get; set; }
        /// <summary>
        /// Users
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// User app usage sessions
        /// </summary>
        public DbSet<UserSession> UserSessions { get; set; }
        /// <summary>
        /// Kids
        /// </summary>
        public DbSet<Kid> Kids { get; set; }
        /// <summary>
        /// Kids
        /// </summary>
        public DbSet<UserKid> UserKids { get; set; }
        /// <summary>
        /// Kindergarden groups
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasIndex(p => new { p.Phone }).HasFilter("\"IsDeleted\" != true").IsUnique();

            modelBuilder.Entity<User>().HasIndex(p => new { p.Phone }).HasFilter("\"IsDeleted\" != true").IsUnique();
            modelBuilder.Entity<User>().HasMany(user => user.Kids).WithOne(userKid => userKid.User);

            modelBuilder.Entity<UserKid>().HasIndex(p => new { p.UserId, p.KidId }).HasFilter("\"IsDeleted\" != true").IsUnique();
            modelBuilder.Entity<Group>().HasIndex(p => new { p.Name }).HasFilter("\"IsDeleted\" != true").IsUnique();

            SetQueryFilters(modelBuilder);
        }

        private void SetQueryFilters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<UserKid>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Kid>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Group>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
