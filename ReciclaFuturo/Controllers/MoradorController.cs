using Microsoft.AspNetCore.Mvc;
using ReciclaFuturo.Models;
using ReciclaFuturo.Services;

namespace ReciclaFuturo.Controllers
{
    public class MoradorController : Controller
    {
        private readonly InterfaceMoradorService _moradorService;

        public MoradorController(InterfaceMoradorService moradorService)
        {
            _moradorService = moradorService;
        }

        public IActionResult Index()
        {
            var moradores = _moradorService.GetAllMoradores();
            return View(moradores);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MoradorModel moradorModel)
        {
            if (ModelState.IsValid)
            {
                _moradorService.CreateMorador(moradorModel);
                TempData["mensagemSucesso"] = $"O morador {moradorModel.Nome} foi cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View(moradorModel);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var morador = _moradorService.GetMoradorById(id);
            if (morador == null)
            {
                return NotFound();
            }
            return View(morador);
        }

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var morador = _context.Morador
        //              .Include(m => m.Endereco)
        //              .FirstOrDefault(m => m.MoradorId == id);
        //    if (morador == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(morador);
        //}

        //[HttpPost]
        //public IActionResult Edit(MoradorModel moradorModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(moradorModel);
        //        _context.SaveChanges();
        //        TempData["mensagemSucesso"] = $"Os dados do morador {moradorModel.Nome} foram alterados com sucesso";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(moradorModel);
        //}

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var morador = _context.Morador.Find(id);
        //    if (morador != null)
        //    {
        //        _context.Morador.Remove(morador);
        //        _context.SaveChanges();
        //        TempData["mensagemSucesso"] = $"Os dados do morador {morador.Nome} foram removidos com sucesso";
        //    }
        //    else
        //    {
        //        TempData["mensagemSucesso"] = "OPS !!! Morador inexistente.";
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
