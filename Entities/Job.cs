using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;
using TpIntegradorSofttek.DTOs;

namespace TpIntegradorSofttek.Entities
{
    public class Job
    {

		public Job()
		{

		}
		public Job(int id)
		{
			CodJob = id;
		}

		public Job(JobDto dto, int id)
		{
			CodJob = id;
			Date = dto.Date;
			CodProject = dto.CodProject;
			CodService = dto.CodService;
			AmountHours = dto.AmountHours;
			HourValue = dto.HourValue;
			Price = dto.Price;
			IsActive = true;
		}

		public Job(JobDto dto)
		{
			Date = dto.Date;
			CodProject = dto.CodProject;
			CodService = dto.CodService;
			AmountHours = dto.AmountHours;
			HourValue = dto.HourValue;
			Price = dto.Price;
			IsActive = true;
		}

		[Key]
		[Column("codJob")]
		public int CodJob { get; set; }

		//funciona		
		//el nombre de la variable y el nombre de la FK en la notation deben ser exactamente el mismo
		[Required]
		[Column("codProject")]
		public int CodProject { get; set; }
		[ForeignKey("CodProject")]
		public Project? Project { get; set; }


		[Required]
		[Column("codService")]
		public int CodService { get; set; }

		[ForeignKey("CodService")]
		public Service? Service { get; set; }

		[Required]
        [Column("date")]
        public DateTime Date { get; set; }

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
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}
