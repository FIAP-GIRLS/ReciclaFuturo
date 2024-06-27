namespace Fiap.Api.Alunos.Services
{
    using Fiap.Api.Alunos.Exceptions;
    using Fiap.Api.Alunos.Models;
    using Fiap.Api.Alunos.Repositories;
    using Fiap.Api.Alunos.Validators;
    using Fiap.Api.Alunos.ViewModels;
    using System.Security.Cryptography;
    using System.Text;


    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserValidator _userValidator;
        private readonly UserLoginViewModelValidator _loginValidator;

        public UserService(UserRepository userRepository, UserValidator userValidator, UserLoginViewModelValidator loginValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
            _loginValidator = loginValidator;
        }

        public UserModel Register(UserViewModel userViewModel)
        {
            var validationResult = _userValidator.Validate(userViewModel);
            if (!validationResult.IsValid)
            {
                throw new CustomException(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var existingUser = _userRepository.GetByEmail(userViewModel.Email);
            if (existingUser != null)
            {
                throw new CustomException("E-mail já existe.");
            }

            var hashedPassword = HashPassword(userViewModel.Senha);

            var user = new UserModel
            {
                Email = userViewModel.Email,
                Senha = hashedPassword,
                Nome = userViewModel.Nome,
                CPF = userViewModel.CPF,
                NumeroDeContato = userViewModel.NumeroDeContato,
                EnderecoNome = userViewModel.EnderecoNome,
                EnderecoNumero = userViewModel.EnderecoNumero,
                Complemento = userViewModel.Complemento,
                CEP = userViewModel.CEP,
                Bairro = userViewModel.Bairro,
                Cidade = userViewModel.Cidade,
                Estado = userViewModel.Estado
            };

            return _userRepository.Add(user);
        }

        public UserModel Login(UserLoginViewModel userLoginViewModel)
        {
            var validationResult = _loginValidator.Validate(userLoginViewModel);
            if (!validationResult.IsValid)
            {
                throw new CustomException(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var user = _userRepository.GetByEmail(userLoginViewModel.Email);
            if (user == null || !VerifyPassword(userLoginViewModel.Senha, user.Senha))
            {
                throw new CustomException("E-mail ou senha inválidos.");
            }

            return user;
        }

        public UserModel GetUserByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        private string HashPassword(string senha)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(hashedBytes);
        }

        private bool VerifyPassword(string senha, string storedHash)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            var hashedPassword = Convert.ToBase64String(hashedBytes);
            return hashedPassword == storedHash;
        }
    }

}
