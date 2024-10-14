using System.ComponentModel.DataAnnotations;

namespace ReciclaFuturo.Models
{
    public class MoradorModel
    {

        public int MoradorId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome não pode ter mais de 64 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [RegularExpression(@"\d{11}", ErrorMessage = "CPF deve ter 11 dígitos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Senha deve ter entre 8 e 16 caracteres")]
        public string? Senha { get; set; }

        [Phone(ErrorMessage = "Número de contato inválido")]
        public string? ContatoNr { get; set; }

        public int EnderecoId { get; set; }
        public EnderecoModel? Endereco { get; set; }

        public List<AgendamentoModel> Agendamentos { get; set; } = new List<AgendamentoModel>();

    }
}
