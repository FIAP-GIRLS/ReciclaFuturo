using System.ComponentModel.DataAnnotations;

namespace ReciclaFuturo.Models
{
    public class AgendamentoModel
    {
        public int AgendamentoId { get; set; }

        [Required(ErrorMessage = "Data e hora do agendamento são obrigatórias")]
        public DateTime? DataHoraAgendamento { get; set; }

        [Required(ErrorMessage = "Morador é obrigatório")]
        public int MoradorId { get; set; }
        public MoradorModel? Morador { get; set; }

        [Required(ErrorMessage = "Rota é obrigatória")]
        public int RotaId { get; set; }
        public RotaModel? Rota { get; set; }

        public List<ResiduoModel> Residuos { get; set; } = new List<ResiduoModel>();
    }
}
