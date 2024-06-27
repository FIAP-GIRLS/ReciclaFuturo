namespace ReciclaFuturo.Models
{
    public class ResiduoModel
    {
        public int ResiduoId { get; set; }
        public string ResiduoNome { get; set; }
        public string TipoResiduo { get; set; }
        public int QtdResiduo { get; set; }
        public string MedidaResiduo { get; set; }

        public int AgendamentoId { get; set; }
        public AgendamentoModel? Agendamento { get; set; }
    }
}
