using ReciclaFuturo.Data.Contexts;
using ReciclaFuturo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ReciclaFuturo.Services
{
    public class AgendamentoService : InterfaceAgendamentoService
    {
        private readonly DatabaseContext _context;

        public AgendamentoService(DatabaseContext context)
        {
            _context = context;
        }

        public List<AgendamentoModel> GetAllAgendamentos()
        {
            return _context.Agendamento.Include(a => a.Morador)
                                       .Include(a => a.Residuos)
                                       .ToList();
        }

        public AgendamentoModel? GetAgendamentoById(int id)
        {
            return _context.Agendamento.Include(a => a.Morador)
                                       .Include(a => a.Residuos)
                                       .FirstOrDefault(a => a.AgendamentoId == id);
        }

        public void CreateAgendamento(AgendamentoModel agendamento)
        {
            _context.Agendamento.Add(agendamento);
            _context.SaveChanges();
        }
    }
}
