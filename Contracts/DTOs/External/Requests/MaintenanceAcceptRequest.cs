using System;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record MaintenanceAcceptRequest(
        Guid UserId,
        Guid NoteId,
        double Cost
        );
}
