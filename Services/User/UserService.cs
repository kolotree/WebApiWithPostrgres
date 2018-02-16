using CSharpFunctionalExtensions;
using Repository.User;

namespace Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = new UserRepository();

        public Result Create(string userName, string passwordHash)
        {
            return _userRepository.Create(userName, passwordHash);
        }

        public Result<string> GetPasswordHash(string userName)
        {
            return _userRepository.GetPasswordHash(userName);
        }
    }
}
