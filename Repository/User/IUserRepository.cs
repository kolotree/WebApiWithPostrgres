using CSharpFunctionalExtensions;

namespace Repository.User
{
    public interface IUserRepository
    {
        Result Create(string userName, string passwordHash);
        Result<string> GetPasswordHash(string userName);
    }
}
