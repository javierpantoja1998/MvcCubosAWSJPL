using Microsoft.AspNetCore.Mvc;
using MvcCubosAWSJPL.Models;
using MvcCubosAWSJPL.Repositories;

namespace MvcCubosAWSJPL.Controllers
{
    public class CubosController : Controller
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> GetCubos()
        {
            List<Cubo> personajes = await this.repo.GetCubosAsync();
            return View(personajes);
        }

        public async Task<IActionResult> Details(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }

        public IActionResult InsertCubo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertCubo(Cubo cubo)
        {
            await this.repo.CreateCubo
                (cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return RedirectToAction("GetCubos");
        }
        public async Task<IActionResult> UpdateCubo(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCubo(Cubo cubo)
        {
            await this.repo.UpdateCuboAsync
                (cubo.IdCubo, cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return RedirectToAction("GetCubos");
        }

        public async Task<IActionResult> DeleteCubo(int id)
        {
            await this.repo.DeleteCuboAsync(id);
            return RedirectToAction("GetCubos");
        }
    }
}
