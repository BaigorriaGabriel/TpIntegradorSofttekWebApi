using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cors.Infrastructure;
using TpIntegradorSofttek.DTOs;

namespace TpIntegradorSofttek.Entities
{
    public class Project
    {
        public Project()
        {
            
        }
        public Project(int id)
        {
            CodProject = id;

        }

        public Project(ProjectDto dto)
        {
            Name = dto.Name;
            Address = dto.Address;
            Status = dto.Status;
            IsActive = true;
        }

        public Project(ProjectDto dto, int id)
        {
            CodProject = id;
            Name = dto.Name;
            Address = dto.Address;
            Status = dto.Status;
            IsActive = true;
        }

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
