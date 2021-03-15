using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SmartLocker.WebAPI.Contracts.DTOs.Internal;
using SmartLocker.WebAPI.Data;
using SmartLocker.WebAPI.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Services
{
    public class DataService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;

        public DataService(ApplicationContext applicationContext, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector(DataProtectionPurposes.DataService);
        }

        public async Task<byte[]> ExportAsync()
        {
            DbData data = await LoadDbDataAsync();
            string jsonData = JsonSerializer.Serialize(data);
            string jsonEncoded = protector.Protect(jsonData);
            
            return Encoding.UTF8.GetBytes(jsonEncoded);
        }

        public async Task ImportAsync(byte[] importFileContent)
        {
            string jsonEncoded = Encoding.UTF8.GetString(importFileContent);
            string json = protector.Unprotect(jsonEncoded);
            DbData data = JsonSerializer.Deserialize<DbData>(json);
            
            await LoadDataToDbAsync(data);
        }

        private async Task LoadDataToDbAsync(DbData data)
        {
            await applicationContext.Users.AddRangeAsync(data.Users);
            await applicationContext.Tools.AddRangeAsync(data.Tools);
            await applicationContext.ServiceBooks.AddRangeAsync(data.ServiceBooks);
            await applicationContext.Lockers.AddRangeAsync(data.Lockers);
            await applicationContext.AccountingNotes.AddRangeAsync(data.AccountingNotes);
            await applicationContext.QueueNotes.AddRangeAsync(data.QueueNotes);
            await applicationContext.ServiceNotes.AddRangeAsync(data.ServiceNotes);
            await applicationContext.ViolationNotes.AddRangeAsync(data.ViolationNotes);

            await applicationContext.SaveChangesAsync();
        }

        private async Task<DbData> LoadDbDataAsync() =>
            new (
                await applicationContext.Users.AsNoTracking().ToListAsync(),
                await applicationContext.Tools.AsNoTracking().ToListAsync(),
                await applicationContext.ServiceBooks.AsNoTracking().ToListAsync(),
                await applicationContext.Lockers.AsNoTracking().ToListAsync(),
                await applicationContext.AccountingNotes.AsNoTracking().ToListAsync(),
                await applicationContext.QueueNotes.AsNoTracking().ToListAsync(),
                await applicationContext.ServiceNotes.AsNoTracking().ToListAsync(),
                await applicationContext.ViolationNotes.AsNoTracking().ToListAsync()
                );
    }
}
