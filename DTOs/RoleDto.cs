using System.ComponentModel.DataAnnotations.Schema;

namespace TpIntegradorSofttek.DTOs
{
    public class RoleDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
