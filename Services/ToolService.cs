using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Data;
using SmartLocker.WebAPI.Domain;
using SmartLocker.WebAPI.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Services
{
    public class ToolService
    {
        private readonly ApplicationContext applicationContext;
        private readonly ServiceBookService bookService;
        private readonly IStringLocalizer localizer;
        private readonly IDataProtector dataProtector;

        public ToolService(ApplicationContext applicationContext, ServiceBookService bookService, IStringLocalizer localizer, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            this.bookService = bookService;
            this.localizer = localizer;
            dataProtector = provider.CreateProtector(DataProtectionPurposes.ToolService);
        }

        public async Task<List<Tool>> GetAllAsync() =>
            await applicationContext.Tools.Include(t => t.ServiceBook).ToListAsync();


        public async Task<Tool> GetOneAsync(Guid id)
        {
            Tool tool = await applicationContext.Tools.Include(t => t.ServiceBook).AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

            if (tool is null)
                throw new Exception(localizer["Tool with this identifier doesn`t exist."]);

            return tool;
        }

        public async Task CreateAsync(ToolCreateRequest request)
        {
            Tool tool = new (request);

            await applicationContext.Tools.AddAsync(tool);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Tool> EditAsync(Guid id, ToolEditRequest request)
        {
            Tool newTool = new(request);
            Tool tool = await GetOneAsync(id);
           
            tool = newTool;
            tool.Id = id;

            applicationContext.Tools.Update(tool);
            await applicationContext.SaveChangesAsync();

            return await GetOneAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            Tool tool = await GetOneAsync(id);

            applicationContext.Tools.Remove(tool);
            await applicationContext.SaveChangesAsync();
        }
    }
}
