using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Repositories
{
    public class UserRepository
    {
        private readonly List<UserModel> _users = new();

        public UserModel Add(UserModel user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
            return user;
        }

        public UserModel GetByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }
    }

}
