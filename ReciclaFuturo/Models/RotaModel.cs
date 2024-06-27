namespace ReciclaFuturo.Models
{
    public class RotaModel
    {
        public int RotaId { get; set; }
        public DateTime DataHoraRota { get; set; }
        public string StatusRota { get; set; }
        public int AgendamentoId { get; set; }
        public AgendamentoModel Agendamento { get; set; }
        public int VeiculoId { get; set; }
        public VeiculoModel Veiculo { get; set; }
    }
}
