using Microsoft.AspNetCore.Mvc;
using ReciclaFuturo.Models;
using ReciclaFuturo.Services;

namespace ReciclaFuturo.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly InterfaceAgendamentoService _agendamentoService;
        private readonly InterfaceMoradorService _moradorService;

        public AgendamentoController(InterfaceAgendamentoService agendamentoService, InterfaceMoradorService moradorService)
        {
            _agendamentoService = agendamentoService;
            _moradorService = moradorService;
        }

        public IActionResult Index()
        {
            var agendamentos = _agendamentoService.GetAllAgendamentos();
            return View(agendamentos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Moradores = _moradorService.GetAllMoradores();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AgendamentoModel agendamentoModel)
        {
            if (ModelState.IsValid)
            {
                _agendamentoService.CreateAgendamento(agendamentoModel);
                TempData["mensagemSucesso"] = $"O agendamento foi criado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Moradores = _moradorService.GetAllMoradores();
            return View(agendamentoModel);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var agendamento = _agendamentoService.GetAgendamentoById(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            return View(agendamento);
        }
    }
}
