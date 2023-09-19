using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TpIntegradorSofttek.Entities
{
    public class Service
    {

        [Key]
        [Column("codService")]
        public int CodService { get; set; }

        [Required]
        [Column("description", TypeName = "VARCHAR(200)")]
        public string Description { get; set; }

        [Required]
        [Column("isActive")]
        public bool IsActive { get; set; }

        [Required]
        [Column("hourValue")]
        public float HourValue { get; set; }

    }
}
