using SmartLocker.WebAPI.Domain;
using SmartLocker.WebAPI.Domain.RegisterNotes;
using System.Collections.Generic;

namespace SmartLocker.WebAPI.Contracts.DTOs.Internal
{
    public record DbData(
        List<User> Users,
        List<Tool> Tools,
        List<ServiceBook> ServiceBooks,
        List<Locker> Lockers,
        List<AccountingRegisterNote> AccountingNotes,
        List<QueueRegisterNote> QueueNotes,
        List<ServiceRegisterNote> ServiceNotes,
        List<ViolationRegisterNote> ViolationNotes      
        );
}
