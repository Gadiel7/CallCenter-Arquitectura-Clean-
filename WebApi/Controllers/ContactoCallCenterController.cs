using Aplication.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactoCallCenterController : ControllerBase
    {
        private readonly ContactoCallCenterUseCase _useCase;

        public ContactoCallCenterController(ContactoCallCenterUseCase useCase)
        {
            _useCase = useCase;
        }

        // 🔥 ENDPOINT QUE EL DASHBOARD NECESITA
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _useCase.ObtenerTodos();
            return Ok(data);
        }
    }
}
