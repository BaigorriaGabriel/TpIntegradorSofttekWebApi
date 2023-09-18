using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TpIntegradorSofttek.Entities;

namespace TpIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public class UserSeeder: IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    CodUser=1,
                    Name="Gabriel Baigorria",
                    Dni="44504788",
                    Type=1,
                    Password="1234",
                    state=true
                },
                new User
                {
                    CodUser = 2,
                    Name = "Felipe Morato",
                    Dni = "45000001",
                    Type = 2,
                    Password = "1234",
                    state = true
                });
        }
    }
}
