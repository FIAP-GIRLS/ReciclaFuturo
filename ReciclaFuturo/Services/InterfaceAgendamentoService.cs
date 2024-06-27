using ReciclaFuturo.Models;
using System.Collections.Generic;

namespace ReciclaFuturo.Services
{
    public interface InterfaceAgendamentoService
    {
        List<AgendamentoModel> GetAllAgendamentos();
        AgendamentoModel? GetAgendamentoById(int id);
        void CreateAgendamento(AgendamentoModel agendamento);
    }
}
