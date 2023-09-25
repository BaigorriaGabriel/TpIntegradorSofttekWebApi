using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helper;

namespace TpIntegradorSofttek.Entities
{
    public class Service
    {

        public Service()
        {
            IsActive = true;
        }

        public Service(ServiceDto dto)
        {
            Description = dto.Description;
            Status = dto.Status;
            HourValue = dto.HourValue;
            IsActive = true;
        }

        public Service(ServiceDto dto, int id)
        {
            CodService = id;
            Description = dto.Description;
            Status = dto.Status;
            HourValue = dto.HourValue;
            IsActive = true;
        }

        public Service(int id)
        {
            CodService = id;

        }

        [Key]
        [Column("codService")]
        public int CodService { get; set; }

        [Required]
        [Column("description", TypeName = "VARCHAR(200)")]
        public string Description { get; set; }

        [Required]
        [Column("status")]
        public bool Status { get; set; }

        [Required]
        [Column("hourValue")]
        public float HourValue { get; set; }


        [Required]
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}
