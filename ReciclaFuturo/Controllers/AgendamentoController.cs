using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReciclaFuturo.Data.Contexts;
using ReciclaFuturo.Models;

namespace ReciclaFuturo.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly DatabaseContext _context;

        public AgendamentoController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var agendamentos = _context.Agendamento
                                       .Include(a => a.Morador)
                                       .Include(a => a.Rota)
                                       .ToList();
            return View(agendamentos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Moradores = _context.Morador.ToList();
            ViewBag.Rotas = _context.Rota.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AgendamentoModel agendamentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Agendamento.Add(agendamentoModel);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"O agendamento foi criado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Moradores = _context.Morador.ToList();
            ViewBag.Rotas = _context.Rota.ToList();
            return View(agendamentoModel);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var agendamento = _context.Agendamento
                                      .Include(a => a.Morador)
                                      .Include(a => a.Rota)
                                      .FirstOrDefault(a => a.AgendamentoId == id);

            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var agendamento = _context.Agendamento
                                      .Include(a => a.Morador)
                                      .Include(a => a.Rota)
                                      .FirstOrDefault(a => a.AgendamentoId == id);
            if (agendamento == null)
            {
                return NotFound();
            }
            ViewBag.Moradores = _context.Morador.ToList();
            ViewBag.Rotas = _context.Rota.ToList();
            return View(agendamento);
        }

        [HttpPost]
        public IActionResult Edit(AgendamentoModel agendamentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(agendamentoModel);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do agendamento foram alterados com sucesso";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Moradores = _context.Morador.ToList();
            ViewBag.Rotas = _context.Rota.ToList();
            return View(agendamentoModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var agendamento = _context.Agendamento.Find(id);
            if (agendamento != null)
            {
                _context.Agendamento.Remove(agendamento);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do agendamento foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemSucesso"] = "OPS !!! Agendamento inexistente.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
