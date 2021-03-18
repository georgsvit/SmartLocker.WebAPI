using System;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record ToolCreateRequest(
        string Name,
        string Description,
        string ImgUrl,
        int AccessLevel,
        DateTime LastServiceDate,
        long MsBetweenServices,
        int MaxUsages,
        int Usages
        );
}
