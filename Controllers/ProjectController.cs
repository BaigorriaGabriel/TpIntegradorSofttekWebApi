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
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		/// <summary>
		/// Devuelve todos los Proyectos activos, la entrada define el numero de pagina que muestra el Endpoint, por defecto 1
		/// </summary>
		/// <returns></returns>
		[HttpGet("GetAllActive")]
        [Authorize]
        public async Task<IActionResult> GetAllActive(int pageToShow = 1)
        {
            var projects = await _unitOfWork.ProjectRepository.GetAllActive();

			if (Request.Query.ContainsKey("page")) { int.TryParse(Request.Query["page"], out pageToShow); }

			var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

			var paginateProjects = PaginateHelper.Paginate(projects, pageToShow, url);

			return ResponseFactory.CreateSuccessResponse(200, paginateProjects);
        }

        /// <summary>
        /// Devuleve un Proyecto por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //devuelve el proyecto incluso si esta dado de baja (logicamente)
        [HttpGet("GetById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (await _unitOfWork.ProjectRepository.ProjectExById(id))
            {
                var project = await _unitOfWork.ProjectRepository.GetById(new Project(id));

                return ResponseFactory.CreateSuccessResponse(200, project);
            }
            return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Proyecto con el Id: {id}");
        }


		/// <summary>
		/// Devuleve todos los Proyectos activos con el Status que se ingresa
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("GetByStatus/{status}")]
		[Authorize]
		public async Task<IActionResult> GetByStatus([FromRoute] int status)
		{
			if (status == 1 || status == 2 || status == 3)
			{
                Project project = new Project();
				project.Status = status;
				var projects = await _unitOfWork.ProjectRepository.GetByStatus(project);

				return ResponseFactory.CreateSuccessResponse(200, projects);
			}
			return ResponseFactory.CreateErrorResponse(404, $"Status Invalido");
		}


		/// <summary>
		/// Agrega un Proyecto
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost]
        [Route("Create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create(ProjectDto dto)
        {
            var project = new Project(dto);
			if (dto.Status == 1 || dto.Status == 2 || dto.Status == 3)
            {
				await _unitOfWork.ProjectRepository.Insert(project);
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Proyecto agregado con exito!");
            }
			return ResponseFactory.CreateErrorResponse(409, $"Status Invalido");
		}

        /// <summary>
        /// Actualiza un Proyecto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, ProjectDto dto)
        {
            if (await _unitOfWork.ProjectRepository.ProjectExById(id))
            {
                if(dto.Status == 1 || dto.Status == 2 || dto.Status == 3)
                {
                    var result = await _unitOfWork.ProjectRepository.Update(new Project(dto, id));
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(201, "Proyecto actualizado con exito!");
                }
				return ResponseFactory.CreateErrorResponse(409, $"Status Invalido");
			}
            return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Proyecto con el Id: {id}");
        }

        /// <summary>
        /// Elimina logicamente un Proyecto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            if (await _unitOfWork.ProjectRepository.ProjectExById(id))
            {
                var project = await _unitOfWork.ProjectRepository.GetById(new Project(id));
                if (project.IsActive)
                {
                    var result = await _unitOfWork.ProjectRepository.Delete(new Project(id));
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(201, "Proyecto eliminado con exito!");
                }
                else
                {
                    return ResponseFactory.CreateErrorResponse(409, $"El Proyecto con Id: {id} ya se encuentra eliminado");
                }
            }
            return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Proyecto con el Id: {id}");
        }
    }
}
