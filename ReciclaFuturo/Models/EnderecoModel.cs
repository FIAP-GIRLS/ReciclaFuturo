using System.ComponentModel.DataAnnotations;

public class EnderecoModel
{
    public int EnderecoId { get; set; }

    [Required(ErrorMessage = "Nome do Endereço é obrigatório")]
    public string NomeEndereco { get; set; } = string.Empty;

    [Required(ErrorMessage = "Número do Endereço é obrigatório")]
    public string NumeroEndereco { get; set; } = string.Empty;

    [Required(ErrorMessage = "Bairro é obrigatório")]
    public string Bairro { get; set; } = string.Empty;

    [Required(ErrorMessage = "Estado é obrigatório")]
    public string Estado { get; set; } = string.Empty;

    [Required(ErrorMessage = "Cidade é obrigatória")]
    public string Cidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "CEP é obrigatório")]
    public int Cep { get; set; }
}
