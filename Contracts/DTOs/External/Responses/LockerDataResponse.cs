using SmartLocker.WebAPI.Domain;
using System;
using System.Collections.Generic;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Responses
{
    public record LockerDataResponse(
        Guid Id,
        bool IsFull,
        bool IsBlocked,
        string Login,
        List<Tool> Tools
        );
}
