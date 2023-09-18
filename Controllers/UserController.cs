using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.Entities;
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

        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAll();

            return users;
        }
    }
}
