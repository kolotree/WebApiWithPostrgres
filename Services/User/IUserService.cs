using System.Threading.Tasks;

namespace Services.User
{
    public interface IUserService
    {
        Task Create(string userName, string passwordHash);
        string GetPasswordHash(string userName);
    }
}
