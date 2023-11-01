using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetAllPersonas()
        {
            var personas = await _personaRepository.GetAllPersonasAsync();
            return Ok(personas);
        }

        [HttpGet("{cc}")]
        public async Task<ActionResult<Persona>> GetPersonaById(int id)
        {
            var personaDto = await _personaRepository.GetPersonaByIdAsync(id);
            if (personaDto == null) return NotFound();

            return Ok(personaDto);
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> CreatePersona(Persona persona)
        {
            var nuevaPersona = await _personaRepository.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersonaById), new { cc = nuevaPersona.Cc }, nuevaPersona);
        }

        [HttpPut("{cc}")]
        public async Task<IActionResult> UpdatePersona(int cc, Persona persona)
        {
            if (cc != persona.Cc)
            {
                return BadRequest();
            }

            var personaExistente = await _personaRepository.GetPersonaByIdAsync(cc);
            if (personaExistente == null)
            {
                return NotFound();
            }

            await _personaRepository.UpdatePersonaAsync(persona);
            return NoContent();
        }

        [HttpDelete("{cc}")]
        public async Task<IActionResult> DeletePersona(int cc)
        {
            var personaExistente = await _personaRepository.GetPersonaByIdAsync(cc);
            if (personaExistente == null)
            {
                return NotFound();
            }

            await _personaRepository.DeletePersonaAsync(cc);
            return NoContent();
        }
    }
}
