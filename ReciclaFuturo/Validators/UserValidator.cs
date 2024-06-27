namespace Fiap.Api.Alunos.Validators
{
    using Fiap.Api.Alunos.ViewModels;
    using FluentValidation;

    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório!")
                .EmailAddress().WithMessage("Endereço de e-mail inválido.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória!")
                .MinimumLength(8).WithMessage("Senha deve ter mais que 8 caracteres.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório!");

            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("CPF é obrigatório!")
                .Length(11).WithMessage("CPF deve ter 11 caracteres.");

            RuleFor(x => x.NumeroDeContato)
                .NotEmpty().WithMessage("Número de contato é obrigatório!");

            RuleFor(x => x.EnderecoNome)
                .NotEmpty().WithMessage("Endereço é obrigatório!"); ;

            RuleFor(x => x.EnderecoNumero)
                .NotEmpty().WithMessage("Número do endereço é obrigatório!"); ;

            RuleFor(x => x.CEP)
                .NotEmpty().WithMessage("CEP é obrigatório!"); ;

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("Bairro é obrigatório!"); ;

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Cidade é obrigatório!"); ;

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("Estado é obrigatório!"); ;
        }
    }

}
