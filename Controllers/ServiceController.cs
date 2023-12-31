﻿using Microsoft.AspNetCore.Authorization;
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
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		/// <summary>
		/// Devuelve todos los Servicios activos, la entrada define el numero de pagina que muestra el Endpoint, por defecto 1
		/// </summary>
		/// <returns>Todos los Servicios activos</returns>
		[HttpGet("GetAllActive")]
        [Authorize]
        public async Task<IActionResult> GetAllActive(int pageToShow = 1)
        {
            var services = await _unitOfWork.ServiceRepository.GetAllActive();

			if (Request.Query.ContainsKey("page")) { int.TryParse(Request.Query["page"], out pageToShow); }

			var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

			var paginateServices = PaginateHelper.Paginate(services, pageToShow, url);

			return ResponseFactory.CreateSuccessResponse(200, paginateServices);
        }

        /// <summary>
        /// Devuleve un Servicio por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Servicio por ID</returns>
        //devuelve el servicio incluso si esta dado de baja (logicamente)
        [HttpGet("GetById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (await _unitOfWork.ServiceRepository.ServiceExById(id))
            {
                var service = await _unitOfWork.ServiceRepository.GetById(new Service(id));

                return ResponseFactory.CreateSuccessResponse(200, service);
            }
            return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Servicio con el Id: {id}");
        }

		/// <summary>
		/// Devuelve todos los Servicios con Status activo
		/// </summary>
		/// <returns>Todos los Servicios de Status activo</returns>
		[HttpGet("GetAllActiveStatus")]
		[Authorize]
		public async Task<IActionResult> GetAllActiveStatus()
		{
			var services = await _unitOfWork.ServiceRepository.GetAllActiveStatus();

			return ResponseFactory.CreateSuccessResponse(200, services);
		}

		/// <summary>
		/// Agrega un Servicio
		/// </summary>
		/// <param name="dto"></param>
		/// <returns>Mensaje de confirmacion o error</returns>
		[HttpPost]
        [Route("Create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create(ServiceDto dto)
        {
            var service = new Service(dto);
            await _unitOfWork.ServiceRepository.Insert(service);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Servicio agregado con exito!");
        }

		/// <summary>
		/// Actualiza un Servicio
		/// </summary>
		/// <param name="id"></param>
		/// <param name="dto"></param>
		/// <returns>Mensaje de confirmacion o error</returns>
		[HttpPut("Update/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, ServiceDto dto)
        {
            if(await _unitOfWork.ServiceRepository.ServiceExById(id))
            {
                var result = await _unitOfWork.ServiceRepository.Update(new Service(dto, id));
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Servicio actualizado con exito!");
            }
            return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Servicio con el Id: {id}");
        }

		/// <summary>
		/// Elimina logicamente un Servicio
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Mensaje de confirmacion o error</returns>
		[HttpDelete("Delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            if (await _unitOfWork.ServiceRepository.ServiceExById(id))
            {
                var service = await _unitOfWork.ServiceRepository.GetById(new Service(id));
                if (service.IsActive)
                {
                    var result = await _unitOfWork.ServiceRepository.Delete(new Service(id));
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(201, "Servicio eliminado con exito!");
                }
                else
                {
                    return ResponseFactory.CreateErrorResponse(409, $"El Servicio con Id: {id} ya se encuentra eliminado");
                }
            }
            return ResponseFactory.CreateErrorResponse(404, $"No existe ningun Servicio con el Id: {id}");
        }

    }
}
