using Microsoft.AspNetCore.DataProtection;
using SmartLocker.WebAPI.Data;
using SmartLocker.WebAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using System.IdentityModel.Tokens.Jwt;
using SmartLocker.WebAPI.Contracts.DTOs.Internal;
using SmartLocker.WebAPI.Contracts.DTOs.External.Responses;

namespace SmartLocker.WebAPI.Services
{
    public class AccountService
    {
        protected readonly ApplicationContext applicationContext;
        protected readonly JwtTokenService tokenService;
        protected readonly IDataProtector dataProtector;

        public AccountService(ApplicationContext applicationContext, JwtTokenService tokenService, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            this.tokenService = tokenService;
            this.dataProtector = provider.CreateProtector("AccountService");
        }

        public async Task RegisterAsync(User user)
        {
            if (await IsUserRegisteredAsync(user))
                throw new Exception("The user with such login is already registered.");

            ProtectPassword(user);

            await applicationContext.Users.AddAsync(user);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<DetailedLoginResponse> LoginAsync(LoginRequest loginRequest) 
        {
            var user = await GetUserAsync(loginRequest);

            if (user is null)
                throw new Exception("Login failed.");

            JwtSecurityToken token = tokenService.CreateJwtSecurityToken(new UserIdentity(user.Id, user.Login, user.Password, user.Role));
            string encodedToken = tokenService.EncodeJwtSecurityToken(token);

            return new DetailedLoginResponse(user.Id, user.FirstName, user.LastName, user.Role, encodedToken, token.ValidTo);
        }

        private void ProtectPassword(User user) =>
            user.Password = dataProtector.Protect(user.Password);

        private async Task<bool> IsUserRegisteredAsync(User user)
        {
            var identity = await GetUserByLoginAsync(user.Login);
            return identity is not null;
        }

        private async Task<User> GetUserByLoginAsync(string login) =>
            await applicationContext.Users.FirstOrDefaultAsync(u => u.Login == login);

        private async Task<User> GetUserAsync(LoginRequest loginRequest)
        {
            var user = await GetUserByLoginAsync(loginRequest.Login);

            if (user is null) 
                throw new Exception("The user with such login doesn`t exist.");

            var invalidPassword = dataProtector.Unprotect(user.Password) != loginRequest.Password;

            if (invalidPassword) 
                throw new Exception("The password isn`t correct.");

            return user;
        }
    }
}
