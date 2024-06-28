using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReciclaFuturo.Data.Contexts;
using ReciclaFuturo.Models;
using ReciclaFuturo.Services;

namespace ReciclaFuturo.Controllers
{
    public class MoradorController : Controller
    {
        private readonly DatabaseContext _context;

        public MoradorController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var moradores = _context.Morador.Include(m => m.Endereco).ToList();
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
                _context.Morador.Add(moradorModel);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"O morador {moradorModel.Nome} foi cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View(moradorModel);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var morador = _context.Morador
                                .Include(m => m.Endereco)
                                .FirstOrDefault(m => m.MoradorId == id);

            if (morador == null)
            {
                return NotFound();
            }

            return View(morador);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var morador = _context.Morador
                      .Include(m => m.Endereco)
                      .FirstOrDefault(m => m.MoradorId == id);
            if (morador == null)
            {
                return NotFound();
            }
            return View(morador);
        }

        [HttpPost]
        public IActionResult Edit(MoradorModel moradorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(moradorModel);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do morador {moradorModel.Nome} foram alterados com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View(moradorModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var morador = _context.Morador.Find(id);
            if (morador != null)
            {
                _context.Morador.Remove(morador);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do morador {morador.Nome} foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemSucesso"] = "OPS !!! Morador inexistente.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
