using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helper;
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

            return Ok(user);
        }


    }
}
