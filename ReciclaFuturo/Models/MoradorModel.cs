namespace ReciclaFuturo.Models
{
    public class MoradorModel
    {

        public int MoradorId { get; set; }
        public string? Nome { get; set; }
        public int cpf { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public string? ContatoNr { get; set; }

        public int EnderecoId { get; set; }
        public EnderecoModel? Endereco { get; set; }

    }
}
