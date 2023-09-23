using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helper;

namespace TpIntegradorSofttek.Entities
{
    public class User
    {

        public User(RegisterDto dto)
        {
            Name = dto.Name;
            Dni= dto.Dni;
            Email = dto.Email;
            RoleId = 2;
            Password = PasswordEncryptHelper.EncryptPassword(dto.Password); ;
            IsActive = true;
        }

        public User(RegisterDto dto , int id)
        {
            CodUser = id;
            Name = dto.Name;
            Dni = dto.Dni;
            Email = dto.Email;
            RoleId = dto.RoleId;
            Password = PasswordEncryptHelper.EncryptPassword(dto.Password); 
            IsActive = true;
        }

        public User( int id)
        {
            CodUser = id;
            
        }

        public User()
        {
            
        }


        [Key]
        [Column("codUser")]
        public int CodUser { get; set; }


        [Required]
        [Column("name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        [Required]
        [Column("email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Required]
        [Column("dni", TypeName = "VARCHAR(10)")]
        public string Dni { get; set; }

        [Required]
        [Column("roleId", TypeName = "Int")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        [Required]
        [Column("password", TypeName = "VARCHAR(250)")]
        public string Password { get; set; }

        [Required]
        [Column("isActive")]
        public bool IsActive { get; set; }

    }
}
