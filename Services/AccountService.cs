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
using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Domain.Constants;

namespace SmartLocker.WebAPI.Services
{
    public class AccountService
    {
        protected readonly ApplicationContext applicationContext;
        protected readonly JwtTokenService tokenService;
        protected readonly IDataProtector dataProtector;
        protected readonly IStringLocalizer localizer;

        public AccountService(ApplicationContext applicationContext, JwtTokenService tokenService, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            this.tokenService = tokenService;
            this.dataProtector = provider.CreateProtector(DataProtectionPurposes.UserService);
            this.localizer = localizer;
        }

        public async Task RegisterAsync(User user)
        {
            if (await IsUserRegisteredAsync(user))
                throw new Exception(localizer["The user with such login is already registered."]);

            ProtectUserData(user);

            await applicationContext.Users.AddAsync(user);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<DetailedLoginResponse> LoginAsync(LoginRequest loginRequest) 
        {
            var user = await GetUserAsync(loginRequest);

            if (user is null)
                throw new Exception(localizer["Login failed."]);

            UnprotectUserData(user);

            JwtSecurityToken token = tokenService.CreateJwtSecurityToken(new UserIdentity(user.Id, user.Login, user.Password, user.Role));
            string encodedToken = tokenService.EncodeJwtSecurityToken(token);

            return new DetailedLoginResponse(user.Id, user.FirstName, user.LastName, user.Role, encodedToken, token.ValidTo);
        }

        private void ProtectUserData(User user)
        {
            user.Password = dataProtector.Protect(user.Password);
            user.FirstName = dataProtector.Protect(user.FirstName);
            user.LastName = dataProtector.Protect(user.LastName);
        }

        private void UnprotectUserData(User user)
        {
            user.FirstName = dataProtector.Unprotect(user.FirstName);
            user.LastName = dataProtector.Unprotect(user.LastName);
        }

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
                throw new Exception(localizer["The user with such login doesn`t exist."]);

            var invalidPassword = dataProtector.Unprotect(user.Password) != loginRequest.Password;

            if (invalidPassword) 
                throw new Exception(localizer["The password isn`t correct."]);

            return user;
        }
    }
}
