using System;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record ServiceNoteCreateRequest(
        Guid ToolId,
        DateTime Date
        );
}
