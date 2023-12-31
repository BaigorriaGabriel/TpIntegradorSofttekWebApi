﻿using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TpIntegradorSofttek.Entities;
using TpIntegradorSofttek.Helper;

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
                    Email="gabi.2912@hotmail.com",
                    Dni="44504788",
                    RoleId = 1,
                    Password= PasswordEncryptHelper.EncryptPassword("1234", "gabi.2912@hotmail.com"),
                    IsActive =true
                },
                new User
                {
                    CodUser = 2,
                    Name = "Felipe Morato",
                    Email = "feli.2003@hotmail.com",
                    Dni = "45000001",
                    RoleId = 2,
                    Password = PasswordEncryptHelper.EncryptPassword("1234", "feli.2003@hotmail.com"),
                    IsActive = true
                });
        }
    }
}
