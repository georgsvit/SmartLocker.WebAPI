using SmartLocker.WebAPI.Domain.RegisterNotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Responses
{
    public record NotificationsResponse(
        List<ServiceRegisterNote> ServiceNotes,
        List<ViolationRegisterNote> ViolationNotes
        );
}
