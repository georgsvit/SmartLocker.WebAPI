using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Data;
using SmartLocker.WebAPI.Domain;
using SmartLocker.WebAPI.Domain.RegisterNotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Services
{
    public class AccountingService
    {
        private readonly ApplicationContext applicationContext;
        private readonly ToolService toolService;
        private readonly IStringLocalizer localizer;

        public AccountingService(ApplicationContext applicationContext, ToolService toolService, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            this.toolService = toolService;
            this.localizer = localizer;
        }

        public async Task AddViolationNote(ViolationNoteCreateRequest request)
        {
            ViolationRegisterNote note = new(request.Date, request.UserId, request.LockerId, request.ToolId);

            var isNoteInDb = await applicationContext.ViolationNotes.FirstOrDefaultAsync(n => n.UserId == request.UserId 
                                                                                           && n.ToolId == request.ToolId
                                                                                           && n.LockerId == request.LockerId
                                                                                           && n.Date == request.Date);

            if (isNoteInDb is not null)
                throw new Exception(localizer["Note already exists."]);

            await applicationContext.ViolationNotes.AddAsync(note);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<List<ViolationRegisterNote>> GetViolationRegister(ViolationNoteGetRequest request) =>
            await applicationContext.ViolationNotes.Where(n => n.Date >= request.StartDate && n.Date <= request.FinishDate)
                                    .Include(n => n.Tool)
                                    .Include(n => n.Locker)
                                    .Include(n => n.User).ToListAsync();

        public async Task AddServiceNote(ServiceNoteCreateRequest request)
        {
            ServiceRegisterNote note = new(request.Date, null, request.ToolId, 0);

            var isNoteInDb = await applicationContext.ServiceNotes.FirstOrDefaultAsync(n => n.ToolId == note.ToolId 
                                                                                         && n.Cost == 0);

            if (isNoteInDb is not null)
                throw new Exception(localizer["Note already exists."]);

            await applicationContext.ServiceNotes.AddAsync(note);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<List<ServiceRegisterNote>> GetServiceRegister(ServiceNoteGetRequest request) =>
            await applicationContext.ServiceNotes.Where(n => n.Date >= request.StartDate && n.Date <= request.FinishDate)
                                    .Include(n => n.Tool)
                                    .Include(n => n.User).ToListAsync();

        public async Task ApplyServiceNote(Guid userId, Guid noteId)
        {
            await CheckUserAndNote(userId, noteId);

            var note = await applicationContext.ServiceNotes.AsNoTracking().FirstOrDefaultAsync(n => n.Id == noteId);

            note.UserId = userId;

            applicationContext.ServiceNotes.Update(note);
            await applicationContext.SaveChangesAsync();
        }

        public async Task AcceptMaintenance(MaintenanceAcceptRequest request)
        {
            await CheckUserAndNote(request.UserId, request.NoteId);

            var note = await applicationContext.ServiceNotes.AsNoTracking().FirstOrDefaultAsync(n => n.Id == request.NoteId);
            var serviceBook = await applicationContext.ServiceBooks.AsNoTracking().FirstOrDefaultAsync(sb => sb.Id == note.ToolId);

            note.Cost = request.Cost;
            serviceBook.Usages = 0;
            serviceBook.LastServiceDate = DateTime.Now;

            applicationContext.ServiceNotes.Update(note);
            applicationContext.ServiceBooks.Update(serviceBook);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<List<ServiceRegisterNote>> GetAvailableServiceTasks() =>
            await applicationContext.ServiceNotes.Where(n => n.Cost == 0 && (n.UserId == Guid.Empty || n.UserId == null)).Include(n => n.Tool).ToListAsync();

        public async Task TakeTool(Guid userId, Guid toolId)
        {
            Tool tool = await toolService.GetOneAsync(toolId);

            if (tool.UserId is not null)
                throw new Exception(localizer["Tool can`t be taken."]);

            tool.UserId = userId;
            tool.LockerId = null;
            await applicationContext.AccountingNotes.AddAsync(new AccountingRegisterNote(DateTime.Now, userId, toolId, true));
            applicationContext.Tools.Update(tool);

            await applicationContext.SaveChangesAsync();
        }

        public async Task ReturnTool(Guid userId, Guid toolId, Guid lockerId)
        {
            Tool tool = await toolService.GetOneAsync(toolId);

            if (tool.UserId == null)
                throw new Exception(localizer["Tool can`t be returned."]);

            tool.UserId = null;
            tool.LockerId = lockerId;
            await applicationContext.AccountingNotes.AddAsync(new AccountingRegisterNote(DateTime.Now, userId, toolId, false));
            applicationContext.Tools.Update(tool);

            await applicationContext.SaveChangesAsync();
        }

        private async Task CheckUserAndNote(Guid userId, Guid noteId)
        {
            var noteInDb = await applicationContext.ServiceNotes.AsNoTracking().FirstOrDefaultAsync(n => n.Id == noteId);
            var userInDb = await applicationContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (noteInDb is null)
                throw new Exception(localizer["Note with this identifier doesn`t exist."]);

            if (userInDb is null)
                throw new Exception(localizer["User with this identifier doesn`t exist."]);
        }
    }
}
