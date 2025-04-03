using API_LLM.Services.Carros;
using API_LLM.Services.Interfaces.Carros;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_LLM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly ICarrosInterface _carroService;

        public CarrosController(ICarrosInterface carroService)
        {
            _carroService = carroService;
        }

        [HttpGet("marca/{marca}")]
        public async Task<IActionResult> GetCarrosPorMarca(string marca)
        {
            var resposta = await _carroService.GetCarrosPorMarcaAsync(marca);
            return Ok(new { resposta });
        }
    }
}
