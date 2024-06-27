namespace ReciclaFuturo.Models
{
    public class MoradorModel
    {

        public int MoradorId { get; set; }
        public string? Nome { get; set; }
        public int Cpf { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? ContatoNr { get; set; }

        public int EnderecoId { get; set; }
        public EnderecoModel? Endereco { get; set; }

        public List<AgendamentoModel> Agendamentos { get; set; } = new List<AgendamentoModel>();

    }
}
