using CSharpFunctionalExtensions;

namespace Services.User
{
    public interface IUserService
    {
        Result Create(string userName, string passwordHash);
        Result<string> GetPasswordHash(string userName);
    }
}
