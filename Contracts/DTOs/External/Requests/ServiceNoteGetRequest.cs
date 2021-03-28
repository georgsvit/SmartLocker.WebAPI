using System;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record ServiceNoteGetRequest(
        DateTime StartDate,
        DateTime FinishDate
        );
}
