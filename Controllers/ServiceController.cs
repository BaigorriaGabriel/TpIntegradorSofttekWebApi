using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Entities;
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

        [HttpGet("GetAllActive")]
        [Authorize]
        public async Task<IActionResult> GetAllActive()
        {
            var servicies = await _unitOfWork.ServiceRepository.GetAllActive();

            return ResponseFactory.CreateSuccessResponse(200, servicies);
        }

        //devuelve el servicio incluso si esta dado de baja (logicamente)
        [HttpGet("GetById/{id}")]
        [Authorize]
        public async Task<ActionResult<Service>> GetById([FromRoute] int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetById(new Service(id));

            return Ok(service);
        }


        [HttpPost]
        [Route("Create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create(ServiceDto dto)
        {
            var service = new Service(dto);
            await _unitOfWork.ServiceRepository.Insert(service);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpPut("Update/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, ServiceDto dto)
        {
            var result = await _unitOfWork.ServiceRepository.Update(new Service(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpDelete("Delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServiceRepository.Delete(new Service(id));
            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}
