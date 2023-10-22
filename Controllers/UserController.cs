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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


		/// <summary>
		/// Devuelve todos los Usuarios activos, la entrada define el numero de pagina que muestra el Endpoint, por defecto 1
		/// </summary>
		/// <returns>Todos los Usuarios activos</returns>

		[HttpGet("GetAllActive")]
        [Authorize]
        public async Task<IActionResult> GetAllActive() //(int pageToShow = 1)
        {
            int pageToShow = 1;

            var users = await _unitOfWork.UserRepository.GetAllActive();

            if(Request.Query.ContainsKey("page")) { int.TryParse(Request.Query["page"], out pageToShow); }

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

            var paginateUsers = PaginateHelper.Paginate(users, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
            
        }

        /// <summary>
        /// Devuelve un Usuario por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario por ID</returns>
        //verifica que exista un usuario con el id ingresado, si existe, devuelve el usuario incluso si esta dado de baja (logicamente)
        //sino, indica error 404
        [HttpGet("GetById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(await _unitOfWork.UserRepository.UserExById(id))
            {
                var users = await _unitOfWork.UserRepository.GetById(new User(id));

                return ResponseFactory.CreateSuccessResponse(200, users);
            }
            return ResponseFactory.CreateErrorResponse(404, $"No existe ningun usuario con el Id: {id}");
        }

		/// <summary>
		/// Registra un Usuario
		/// </summary>
		/// <param name="dto"></param>
		/// <returns>Mensaje de confirmacion o error</returns>
		//verifica que no exista un usuario con el mail a registrar, si existe indica error 409
		[HttpPost]
        [Route("Register")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _unitOfWork.UserRepository.UserExByMail(dto.Email)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el mail: {dto.Email}");
            if (dto.RoleId != 1 && dto.RoleId != 2) return ResponseFactory.CreateErrorResponse(409, $"RoleId Invalido");
            var user = new User(dto);
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.Complete();


            return ResponseFactory.CreateSuccessResponse(201,"Usuario registrado con exito!");
        }

		/// <summary>
		/// Actualiza un Usuario
		/// </summary>
		/// <param name="id"></param>
		/// <param name="dto"></param>
		/// <returns>Mensaje de confirmacion o error</returns>
		//antes de actualizar verifico si el usuario ya existe un usario con el mail a actualizar
		//si ya existe verifico que ese usuario con el mail existente sea el mismo usuario que se esta actualizando
		//si no lo es no lo dejo actualizar.
		[HttpPut("Update/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, RegisterDto dto)
        {
            if (await _unitOfWork.UserRepository.UserExByMail(dto.Email))
            {
                var existingUser = await _unitOfWork.UserRepository.GetByEmail(dto.Email);

                if (existingUser.CodUser != id)
                {
                    return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el mail: {dto.Email}");
                }
                if (dto.RoleId != 1 && dto.RoleId != 2) return ResponseFactory.CreateErrorResponse(409, $"RoleId Invalido");
                var result = await _unitOfWork.UserRepository.Update(new User(dto, id));
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Usuario actualizado con exito!");
            }
			return ResponseFactory.CreateErrorResponse(404, $"No existe ningun usuario con el ID: {id}");
		}

		/// <summary>
		/// Elimina logicamente un Usuario
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Mensaje de confirmacion o error</returns>
		//verifica que exista un usuario con el id ingresado, si existe verifica que este activo, si no esta activo indica error 409
		//si no existe usuario con id ingresado indica error 404
		[HttpDelete("Delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (await _unitOfWork.UserRepository.UserExById(id))
            {
                var user = await _unitOfWork.UserRepository.GetById(new User(id));
                if (user.IsActive)
                {
                    var result = await _unitOfWork.UserRepository.Delete(new User(id));
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(201, "Usuario eliminado con exito!");
                }
                else
                {
                    return ResponseFactory.CreateErrorResponse(409, $"El Usuario con Id: {id} ya se encuentra eliminado");
                }
            }
            return ResponseFactory.CreateErrorResponse(404, $"No existe ningun usuario con el Id: {id}");
        }
         
    }
}
