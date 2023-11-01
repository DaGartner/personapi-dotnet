using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefono>>> GetAllTelefonos()
        {
            var telefonos = await _telefonoRepository.GetAllTelefonosAsync();
            return Ok(telefonos);
        }

        [HttpGet("{num}")]
        public async Task<ActionResult<Telefono>> GetTelefono(string num)
        {
            var telefono = await _telefonoRepository.GetTelefonoByNumAsync(num);
            if (telefono == null)
            {
                return NotFound();
            }
            return Ok(telefono);
        }

        [HttpPost]
        public async Task<ActionResult<Telefono>> CreateTelefono(Telefono telefono)
        {
            var newTelefono = await _telefonoRepository.CreateTelefonoAsync(telefono);
            return CreatedAtAction(nameof(GetTelefono), new { num = newTelefono.Num }, newTelefono);
        }

        [HttpPut("{num}")]
        public async Task<ActionResult> UpdateTelefono(string num, Telefono telefono)
        {
            if (num != telefono.Num)
            {
                return BadRequest();
            }

            var existingTelefono = await _telefonoRepository.GetTelefonoByNumAsync(num);
            if (existingTelefono == null)
            {
                return NotFound();
            }

            await _telefonoRepository.UpdateTelefonoAsync(telefono);
            return NoContent();
        }

        [HttpDelete("{num}")]
        public async Task<ActionResult> DeleteTelefono(string num)
        {
            var existingTelefono = await _telefonoRepository.GetTelefonoByNumAsync(num);
            if (existingTelefono == null)
            {
                return NotFound();
            }

            await _telefonoRepository.DeleteTelefonoAsync(num);
            return NoContent();
        }
    }
}
