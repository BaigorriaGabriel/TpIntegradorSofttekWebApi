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
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }
        /// <summary>
        /// Inicio de sesion
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Usuario con datos mas JWT</returns>
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDto dto )
        {
            var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(dto);
            if (userCredentials == null) { return Unauthorized("Las credenciales son incorrectas"); }

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new UserLoginDto()
            {
                Name = userCredentials.Name,
                Email = userCredentials.Email,
                Dni = userCredentials.Dni,
                RoleId = userCredentials.RoleId,
                IsActive= userCredentials.IsActive,
                Token = token

            };

            //return ResponseFactory.CreateSuccessResponse(200, user);

            //saco el Response para que en el front poder deserializar directamente el objeto user.
            //no se como acceder al objeto desde el Response con el data
            //tal vez para que funcione deberia cambiar la clase del Front de UserLogin y agregarle el Data para poder acceder al data.

            return Ok(user);
        }


        
    }
}
