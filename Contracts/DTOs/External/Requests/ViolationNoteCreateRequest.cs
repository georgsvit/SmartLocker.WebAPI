using System;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record ViolationNoteCreateRequest(
        Guid UserId, 
        Guid LockerId, 
        Guid ToolId, 
        DateTime Date
        );
}
