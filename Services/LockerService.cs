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
    public class LockerService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector dataProtector;
        private readonly IStringLocalizer localizer;

        public LockerService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            dataProtector = provider.CreateProtector(DataProtectionPurposes.LockerService);
            this.localizer = localizer;
        }

        public async Task<List<LockerDataResponse>> GetAllAsync() =>
            await applicationContext.Lockers.Select(l => l.GetLockerDataResponse()).ToListAsync();

        public async Task<Locker> GetOneAsync(Guid id)
        {
            Locker locker = await applicationContext.Lockers.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);

            if (locker is null)
                throw new Exception(localizer["Locker with this identifier doesn`t exist."]);

            return locker;
        }

        public async Task CreateAsync(LockerCreateRequest request)
        {
            Locker locker = new(request.Login, request.Password);

            if (await IsLockerInDbAsync(locker))
                throw new Exception(localizer["Locker already exists."]);

            await applicationContext.Lockers.AddAsync(locker);
            await applicationContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Locker locker = await GetOneAsync(id);

            applicationContext.Lockers.Remove(locker);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Locker> EditAsync(Guid id, LockerEditRequest request)
        {
            Locker newLocker = new(request.Login, request.Password, request.IsFull, request.IsBlocked);
            Locker locker = await GetOneAsync(id);

            if (request.Password != "")
            {
                ProtectPassword(newLocker);
            }
            else
            {
                newLocker.Password = locker.Password;
            }

            locker = newLocker;
            locker.Id = id;

            applicationContext.Lockers.Update(locker);
            await applicationContext.SaveChangesAsync();

            return await GetOneAsync(id);
        }

        public async Task BlockAsync(Guid id)
        {
            Locker locker = await GetOneAsync(id);
            locker.IsBlocked = true;

            applicationContext.Lockers.Update(locker);
            await applicationContext.SaveChangesAsync();
        }

        public async Task UnblockAsync(Guid id)
        {
            Locker locker = await GetOneAsync(id);
            locker.IsBlocked = false;

            applicationContext.Lockers.Update(locker);
            await applicationContext.SaveChangesAsync();
        }

        private async Task<bool> IsLockerInDbAsync(Locker locker)
        {
            var res = await applicationContext.Lockers.FirstOrDefaultAsync(l => l.Login == locker.Login);
            return res is not null;
        }

        private void ProtectPassword(Locker locker) =>
            locker.Password = dataProtector.Protect(locker.Password);
    }
}
