using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiosController : ControllerBase
    {
        private readonly IEstudiosRepository _estudiosRepository;

        public EstudiosController(IEstudiosRepository estudiosRepository)
        {
            _estudiosRepository = estudiosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudio>>> GetAllEstudios()
        {
            return Ok(await _estudiosRepository.GetAllEstudiosAsync());
        }

        [HttpGet("{idProf}/{ccPer}")]
        public async Task<ActionResult<Estudio>> GetEstudioById(int idProf, int ccPer)
        {
            var estudio = await _estudiosRepository.GetEstudiosByIdAsync(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }
            return Ok(estudio);
        }

        [HttpPost]
        public async Task<ActionResult<Estudio>> CreateEstudio(Estudio estudio)
        {
            var newEstudio = await _estudiosRepository.CreateEstudiosAsync(estudio);
            return CreatedAtAction(nameof(GetEstudioById), new { idProf = newEstudio.IdProf, ccPer = newEstudio.CcPer }, newEstudio);
        }

        [HttpPut("{idProf}/{ccPer}")]
        public async Task<ActionResult> UpdateEstudio(int idProf, int ccPer, Estudio estudio)
        {
            var existingEstudio = await _estudiosRepository.GetEstudiosByIdAsync(idProf, ccPer);
            if (existingEstudio == null)
            {
                return NotFound();
            }

            await _estudiosRepository.UpdateEstudiosAsync(estudio);

            return NoContent();
        }

        [HttpDelete("{idProf}/{ccPer}")]
        public async Task<ActionResult> DeleteEstudio(int idProf, int ccPer)
        {
            var existingEstudio = await _estudiosRepository.GetEstudiosByIdAsync(idProf, ccPer);
            if (existingEstudio == null)
            {
                return NotFound();
            }

            await _estudiosRepository.DeleteEstudiosAsync(idProf, ccPer);

            return NoContent();
        }
    }
}
