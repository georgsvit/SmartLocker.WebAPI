using System;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record LockerEditRequest(
        bool IsFull,
        bool IsBlocked,
        string Login,
        string Password
        );
}
