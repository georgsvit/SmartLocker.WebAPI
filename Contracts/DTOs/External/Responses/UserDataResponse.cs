using SmartLocker.WebAPI.Domain;
using SmartLocker.WebAPI.Domain.Constants;
using SmartLocker.WebAPI.Domain.RegisterNotes;
using System;
using System.Collections.Generic;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Responses
{
    public record UserDataResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Role,
        AccessLevel AccessLevel,
        string Login,
        List<Tool> Tools,
        List<ServiceRegisterNote> ServiceNotes,
        List<ViolationRegisterNote> ViolationNotes,
        List<AccountingRegisterNote> AccountingNotes
        );
}
