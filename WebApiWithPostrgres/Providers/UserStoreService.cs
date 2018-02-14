using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using WebApiWithPostrgres.Models;
using Services.User;
using Services;

namespace WebApiWithPostrgres.Providers
{
    internal class UserStoreService : IUserStore<ApplicationUser>
    {

        private readonly IUserService _userService = new ServiceFactory().GetUserServiceInstance();

        public Task CreateAsync(ApplicationUser user)
        {
            return _userService.Create(user.UserName, user.PasswordHash);
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose() {}

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}