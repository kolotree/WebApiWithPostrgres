using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using WebApiWithPostrgres.Models;
using Services.User;
using Services;
using System;
using CSharpFunctionalExtensions;

namespace WebApiWithPostrgres.Providers
{
    internal class UserStoreService : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserEmailStore<ApplicationUser>
    {

        private readonly IUserService _userService = new ServiceFactory().GetUserServiceInstance();

        public Task CreateAsync(ApplicationUser user) => 
               _userService.Create(user.UserName, user.PasswordHash)
                           .OnBoth(result => result.IsSuccess ? 
                                               Task.FromResult<ApplicationUser>(null) : 
                                               Task.FromException(new ArgumentException(result.Error)));

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose() {}

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            // for sake of simplicity, we will set username to be equal to email
            return FindByNameAsync(email);
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string userName) =>
            _userService.GetPasswordHash(userName)
                        .OnBoth(result => result.IsSuccess ? 
                                                Task.FromResult(new ApplicationUser { UserName = userName }) : 
                                                Task.FromResult<ApplicationUser>(null));

        public Task<string> GetEmailAsync(ApplicationUser user)
        {
            return Task.FromResult(user != null ? user.Email : null);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user) =>
            _userService.GetPasswordHash(user.UserName)
                        .OnBoth(result => result.IsSuccess ?
                                                Task.FromResult(result.Value) :
                                                Task.FromResult<string>(null));

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task SetEmailAsync(ApplicationUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            throw new NotImplementedException();
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