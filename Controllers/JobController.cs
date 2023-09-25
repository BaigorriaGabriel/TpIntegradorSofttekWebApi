using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Entities;
using TpIntegradorSofttek.Helper;
using TpIntegradorSofttek.Infrastructure;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		public JobController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// Devuelve todos los Trabajos activos
		/// </summary>
		/// <returns></returns>
		[HttpGet("GetAllActive")]
		[Authorize]
		public async Task<IActionResult> GetAllActive(int pageToShow = 1)
		{
			var jobs = await _unitOfWork.JobRepository.GetAllActive();

			if (Request.Query.ContainsKey("page")) { int.TryParse(Request.Query["page"], out pageToShow); }

			var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

			var paginateJobs = PaginateHelper.Paginate(jobs, pageToShow, url);

			return ResponseFactory.CreateSuccessResponse(200, paginateJobs);
		}

		/// <summary>
		/// Devuleve un Trabajo por ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		//devuelve el proyecto incluso si esta dado de baja (logicamente)
		[HttpGet("GetById/{id}")]
		[Authorize]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			if (await _unitOfWork.JobRepository.JobExById(id))
			{
				var project = await _unitOfWork.JobRepository.GetById(new Job(id));

				return ResponseFactory.CreateSuccessResponse(200, project);
			}
			return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Trabajo con el Id: {id}");
		}


		/// <summary>
		/// Agrega un Trabajo
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Create")]
		[Authorize(Policy = "Admin")]
		public async Task<IActionResult> Create(JobDto dto)
		{
			var job = new Job(dto);
			var project = await _unitOfWork.ProjectRepository.GetById(new Project(dto.CodProject));
			if (await _unitOfWork.ProjectRepository.ProjectExById(dto.CodProject) && project.IsActive)
			{
				var service = await _unitOfWork.ServiceRepository.GetById(new Service(dto.CodService));
				if (await _unitOfWork.ServiceRepository.ServiceExById(dto.CodService) && service.IsActive)
				{
					await _unitOfWork.JobRepository.Insert(job);
					await _unitOfWork.Complete();
					return ResponseFactory.CreateSuccessResponse(201, "Trabajo agregado con exito!");
				}
				return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Servicio activo con el ID: {dto.CodService}");
			}
			return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Proyecto activo con el ID: {dto.CodProject}");
		}

		/// <summary>
		/// Actualiza un Trabajo
		/// </summary>
		/// <param name="id"></param>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut("Update/{id}")]
		[Authorize(Policy = "Admin")]
		public async Task<IActionResult> Update([FromRoute] int id, JobDto dto)
		{
			if (await _unitOfWork.JobRepository.JobExById(id))
			{
				var project = await _unitOfWork.ProjectRepository.GetById(new Project(dto.CodProject));
				if (await _unitOfWork.ProjectRepository.ProjectExById(dto.CodProject) && project.IsActive)
				{
					var service = await _unitOfWork.ServiceRepository.GetById(new Service(dto.CodService));
					if (await _unitOfWork.ServiceRepository.ServiceExById(dto.CodService) && service.IsActive)
					{
						var result = await _unitOfWork.JobRepository.Update(new Job(dto, id));
						await _unitOfWork.Complete();
						return ResponseFactory.CreateSuccessResponse(201, "Trabajo actualizado con exito!");
					}

					return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Servicio activo con el ID: {dto.CodService}");
				}
				return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Proyecto activo con el ID: {dto.CodProject}");
			}
			return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Trabajo activo con el ID: {id}");
		}


		/// <summary>
		/// Elimina logicamente un Trabajo
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("Delete/{id}")]
		[Authorize(Policy = "Admin")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{

			if (await _unitOfWork.JobRepository.JobExById(id))
			{
				var job = await _unitOfWork.JobRepository.GetById(new Job(id));
				if (job.IsActive)
				{
					var result = await _unitOfWork.JobRepository.Delete(new Job(id));
					await _unitOfWork.Complete();
					return ResponseFactory.CreateSuccessResponse(201, "Trabajo eliminado con exito!");
				}
				else
				{
					return ResponseFactory.CreateErrorResponse(409, $"El Trabajo con Id: {id} ya se encuentra eliminado");
				}
			}
			return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Trabajo con el Id: {id}");
		}


	}
}
