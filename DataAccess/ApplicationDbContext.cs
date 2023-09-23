using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAccess.DataBaseSeeding;
using TpIntegradorSofttek.Entities;

namespace TpIntegradorSofttek.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UserSeeder(),
                new RoleSeeder(),
            };

            foreach (var seeder in seeders)
            {

                seeder.SeedDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
