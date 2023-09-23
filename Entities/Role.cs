using System.ComponentModel.DataAnnotations.Schema;
using TpIntegradorSofttek.DTOs;

namespace TpIntegradorSofttek.Entities
{
    public class Role
    {
        [Column ("roleId")]
        public int RoleId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        public Role(RoleDto dto)
        {
            Name = dto.Name;
            Description = dto.Description;
            IsActive = dto.IsActive;
        }
        
        public Role()
        {
            
        }
    }
}
