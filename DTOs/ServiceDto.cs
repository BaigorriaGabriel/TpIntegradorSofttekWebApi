using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TpIntegradorSofttek.DTOs
{
    public class ServiceDto
    {
        public string Description { get; set; }
        public bool Status { get; set; }
        public float HourValue { get; set; }
    }
}
