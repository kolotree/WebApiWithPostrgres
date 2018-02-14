using Services.User;

namespace Services
{
    public class ServiceFactory
    {
        public IUserService GetUserServiceInstance() => new UserService();
    }
}
