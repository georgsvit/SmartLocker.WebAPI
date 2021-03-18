using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Contracts.DTOs.External.Responses;
using SmartLocker.WebAPI.Data;
using SmartLocker.WebAPI.Domain;
using SmartLocker.WebAPI.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Services
{
    public class UserService
    {
        protected readonly ApplicationContext applicationContext;
        protected readonly IDataProtector dataProtector;
        protected readonly IStringLocalizer localizer;

        public UserService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            dataProtector = provider.CreateProtector(DataProtectionPurposes.UserService);
            this.localizer = localizer;
        }

        public async Task<List<UserDataResponse>> GetAllAsync(string role)
        {
            if (role is not null && !Roles.IsRoleValid(role))
                throw new Exception(localizer["Role doesn`t exist."]);

            var users = role is null
                ? await applicationContext.Users.ToListAsync()
                : await applicationContext.Users.Where(u => u.Role == role.ToUpper()).ToListAsync();

            users.ForEach(user => UnprotectUserData(user));

            return users.Select(u => u.GetUserDataResponse()).ToList();
        }

        public async Task<User> GetOneAsync(Guid id)
        {
            User user = await applicationContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                throw new Exception(localizer["User with this identifier doesn`t exist."]);

            UnprotectUserData(user);

            return user;
        }

        public async Task<User> EditAsync(Guid id, UserEditRequest request)
        {
            if (!Roles.IsRoleValid(request.Role))
                throw new Exception(localizer["Role doesn`t exist."]);

            User newUser = new(request.FirstName, request.LastName, request.Role, (AccessLevel)request.AccessLevel, request.Login, request.Password);
            User user = await GetOneAsync(id);

            if (user is null)
                throw new Exception(localizer["User with this identifier doesn`t exist."]);

            user = newUser;
            user.Id = id;

            applicationContext.Users.Update(user);
            await applicationContext.SaveChangesAsync();

            return await GetOneAsync(id);
        }

        private void UnprotectUserData(User user)
        {
            user.FirstName = dataProtector.Unprotect(user.FirstName);
            user.LastName = dataProtector.Unprotect(user.LastName);
        }
    }
}
