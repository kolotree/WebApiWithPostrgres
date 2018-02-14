using Repository.User;
using System.Threading.Tasks;

namespace Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = new UserRepository();

        public Task Create(string userName, string passwordHash)
        {
            return _userRepository.Create(userName, passwordHash);
        }

        public string GetPasswordHash(string userName)
        {
            return _userRepository.GetPasswordHash(userName);
        }
    }
}
