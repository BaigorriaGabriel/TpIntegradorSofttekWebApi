using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TpIntegradorSofttek.Entities;
using TpIntegradorSofttek.Helper;

namespace TpIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    Name ="Admin",
                    Description="Admin",
                    IsActive = true
                },
                new Role
                {
                    RoleId = 2,
                    Name = "Consultant",
                    Description = "Consultant",
                    IsActive = true
                });
        }
    }
}
