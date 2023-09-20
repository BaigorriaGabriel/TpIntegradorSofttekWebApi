using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Entities;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            //var users = await _unitOfWork.UserRepository.GetAll();
            var users =  _unitOfWork.UserRepository.GetAll().Result.Where(x=> x.IsActive == true);

            return Ok(users);
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new User(dto);
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, RegisterDto dto)
        {
            var result = await _unitOfWork.UserRepository.Update(new User(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("{idEliminar}")]
        public async Task<IActionResult> Delete([FromRoute] int idEliminar)
        {
            var result = await _unitOfWork.UserRepository.Delete(new User(idEliminar));
            await _unitOfWork.Complete();
            return Ok(true);
        }


    }
}
