﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Contracts.DTOs.External.Responses;
using SmartLocker.WebAPI.Data;
using SmartLocker.WebAPI.Domain;
using SmartLocker.WebAPI.Domain.Constants;
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
        protected readonly IDataProtector dataProtector;

        public AccountingService(ApplicationContext applicationContext, ToolService toolService, IStringLocalizer localizer, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            this.toolService = toolService;
            this.localizer = localizer;
            dataProtector = provider.CreateProtector(DataProtectionPurposes.UserService);
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

            var tool = await applicationContext.Tools.FirstOrDefaultAsync(t => t.Id == request.ToolId);
            tool.ServiceState = ServiceStates.SERVICE_REQUESTED;

            applicationContext.Tools.Update(tool);
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

            var tool = await applicationContext.Tools.FirstOrDefaultAsync(t => t.Id == note.ToolId);
            tool.ServiceState = ServiceStates.IN_SERVICE;

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

            var tool = await applicationContext.Tools.FirstOrDefaultAsync(t => t.Id == note.ToolId);
            tool.ServiceState = ServiceStates.SERVED;

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

            tool.ServiceBook.Usages++;

            if (tool.ServiceBook.Usages >= tool.ServiceBook.MaxUsages 
                || (DateTime.Now - tool.ServiceBook.LastServiceDate).TotalMilliseconds >= tool.ServiceBook.MsBetweenServices)
            {
                tool.ServiceState = ServiceStates.SERVICE_REQUIRED;
            }

            applicationContext.Tools.Update(tool);

            await applicationContext.SaveChangesAsync();
        }

        public async Task<NotificationsResponse> GetNotifications()
        {
            var serviceNotes = await applicationContext.ServiceNotes.Where(sn => !sn.IsViewed)
                                    .Include(n => n.Tool)
                                    .Include(n => n.User).ToListAsync();
            var violationNotes = await applicationContext.ViolationNotes.Where(sn => !sn.IsViewed)
                                    .Include(n => n.Tool)
                                    .Include(n => n.Locker)
                                    .Include(n => n.User).ToListAsync();

            serviceNotes.Where(n => n.User is not null).ToList().ForEach(n => n.User.RemoveUselessData());
            serviceNotes.Where(n => n.User is not null).Select(n => n.User).Distinct().ToList().ForEach(u => UnprotectUserData(u));

            violationNotes.Where(n => n.User is not null).ToList().ForEach(n => n.User.RemoveUselessData());
            violationNotes.Where(n => n.User is not null).Select(n => n.User).Distinct().ToList().ForEach(u => UnprotectUserData(u));

            return new(serviceNotes, violationNotes);
        }

        public async Task SetNotificationViewed(Guid id)
        {
            var serviceNote = await applicationContext.ServiceNotes.AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);

            if (serviceNote is not null)
            {
                serviceNote.IsViewed = true;
                applicationContext.ServiceNotes.Update(serviceNote);
            }

            var violationNote = await applicationContext.ViolationNotes.AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);

            if (violationNote is not null)
            {
                violationNote.IsViewed = true;
                applicationContext.ViolationNotes.Update(violationNote);
            }

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

        private void UnprotectUserData(User user)
        {
            user.FirstName = dataProtector.Unprotect(user.FirstName);
            user.LastName = dataProtector.Unprotect(user.LastName);
        }
    }
}
