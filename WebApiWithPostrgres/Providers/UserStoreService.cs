using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using WebApiWithPostrgres.Models;
using Services.User;
using Services;
using System;

namespace WebApiWithPostrgres.Providers
{
    internal class UserStoreService : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
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
            var passwordHash = _userService.GetPasswordHash(userName);
            return Task.FromResult(passwordHash != null ? new ApplicationUser { UserName = userName} : null);
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            var passwordHash = _userService.GetPasswordHash(user.UserName);
            return Task.FromResult(passwordHash != null ? passwordHash : null);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            if (user == null || passwordHash == null)
            {
                return Task.FromException(new ArgumentNullException("User and password cannot be null"));
            }
            user.PasswordHash = passwordHash;
            return Task.FromResult<ApplicationUser>(user);
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}