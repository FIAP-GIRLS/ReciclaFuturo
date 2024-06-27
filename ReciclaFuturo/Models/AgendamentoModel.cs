namespace ReciclaFuturo.Models
{
    public class AgendamentoModel
    {
        public int AgendamentoId { get; set; }
        public DateTime? DataHoraAgendamento { get; set; }

        public int MoradorId { get; set; }
        public MoradorModel? Morador { get; set; }
        public int RotaId { get; set; }
        public RotaModel? Rota { get; set; }

        public List<ResiduoModel> Residuos { get; set; } = new List<ResiduoModel>();
    }
}
