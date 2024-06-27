using System.Globalization;

namespace ReciclaFuturo.Models
{
    public class EnderecoModel
    {

        public int EnderecoId { get; set; }
        public string? NomeEndereco { get; set; }
        public int? NumeroEndereco { get; set; }
        public string? Bairro { get; set; }
        public int? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? complemento { get; set; }

        public int MoradorId { get; set; }
        public MoradorModel? Morador { get; set; }
    }
}
