﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Entities;
using TpIntegradorSofttek.Helper;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        

        [HttpGet("GetAllActive")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetAllActive()
        {
            var users = await _unitOfWork.UserRepository.GetAllActive();

            return Ok(users);
        }


        //devuelve el usuario incluso si esta dado de baja (logicamente)
        [HttpGet("GetById/{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetById([FromRoute] int id)
        {
            var users = await _unitOfWork.UserRepository.GetById(new User(id));

            return Ok(users);
        }


        [HttpPost]
        [Route("Register")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new User(dto);
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpPut("Update/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, RegisterDto dto)
        {
            var result = await _unitOfWork.UserRepository.Update(new User(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.Delete(new User(id));
            await _unitOfWork.Complete();
            return Ok(true);
        }


    }
}
