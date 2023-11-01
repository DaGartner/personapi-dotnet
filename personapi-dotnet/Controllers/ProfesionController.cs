using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    public class ProfesionController : Controller
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        public async Task<IActionResult> Index()
        {
            var profesiones = await _profesionRepository.GetAllProfesionesAsync();
            return View(profesiones);
        }

        public async Task<IActionResult> Details(int id)
        {
            var profesion = await _profesionRepository.GetProfesionByIdAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                await _profesionRepository.CreateProfesionAsync(profesion);
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var profesion = await _profesionRepository.GetProfesionByIdAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _profesionRepository.UpdateProfesionAsync(profesion);
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var profesion = await _profesionRepository.GetProfesionByIdAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _profesionRepository.DeleteProfesionAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
