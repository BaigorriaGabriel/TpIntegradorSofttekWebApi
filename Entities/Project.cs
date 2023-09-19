using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TpIntegradorSofttek.Entities
{
    public class Project
    {
        [Key]
        [Column("codProject")]
        public int CodProject { get; set; }

        [Required]
        [Column("name", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column("address", TypeName = "VARCHAR(100)")]
        public string Address { get; set; }

        [Required]
        [Column("status")]
        public int Status { get; set; }

        [Required]
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}
