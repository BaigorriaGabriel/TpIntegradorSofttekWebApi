using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TpIntegradorSofttek.Entities
{
    public class Job
    {
        [Key]
        [Column("codJob")]
        public int CodJob { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("codProject")]
        public int CodProject { get; set; }

        [Required]
        [Column("codService")]
        public int CodService { get; set; }

        [Required]
        [Column("amountHours")]
        public int AmountHours { get; set; }

        [Required]
        [Column("hourValue")]
        public float HourValue { get; set; }

        [Required]
        [Column("price")]
        public float Price { get; set; }

        [Required]
        [Column("state")]
        public bool state { get; set; }
    }
}
