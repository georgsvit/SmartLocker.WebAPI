using System;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record ServiceBookEditRequest(
        DateTime LastServiceDate,
        int MsBetweenServices,
        int MaxUsages,
        int Usages
        );
}
