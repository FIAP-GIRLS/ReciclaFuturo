namespace Fiap.Api.Alunos.Validators
{
    using Fiap.Api.Alunos.ViewModels;
    using FluentValidation;

    public class UserLoginViewModelValidator : AbstractValidator<UserLoginViewModel>
    {
        public UserLoginViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório!")
                .EmailAddress().WithMessage("Endereço de e-mail inválido.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória!")
                .MinimumLength(8).WithMessage("Senha deve ter mais que 8 caracteres.");
        }
    }

}
