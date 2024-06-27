namespace ReciclaFuturo.Models
{
    public class AgendamentoModel
    {
        public int AgendamentoId { get; set; }
        public DateTime? DataHoraAgendamento { get; set; }

        public int MoradorId { get; set; }
        public MoradorModel? Morador { get; set; }
    }
}
