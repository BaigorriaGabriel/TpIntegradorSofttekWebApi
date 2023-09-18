using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TpIntegradorSofttek.Entities
{
    public class User
    {
        [Key]
        [Column("codUser")]
        public int CodUser { get; set; }


        [Required]
        [Column("name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }
        
        
        [Required]
        [Column("dni", TypeName = "VARCHAR(10)")]
        public string Dni { get; set; }

        [Required]
        [Column("type", TypeName = "Int")]
        public int Type { get; set; }

        [Required]
        [Column("password", TypeName = "VARCHAR(250)")]
        public string Password { get; set; }

        [Required]
        [Column("state")]
        public bool state { get; set; }

    }
}
