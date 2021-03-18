using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Data;
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
        private readonly IStringLocalizer localizer;

        public AccountingService(ApplicationContext applicationContext, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
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
    }
}
