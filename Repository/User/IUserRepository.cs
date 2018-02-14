using System.Threading.Tasks;

namespace Repository.User
{
    public interface IUserRepository
    {
        Task Create(string userName, string passwordHash);
    }
}
