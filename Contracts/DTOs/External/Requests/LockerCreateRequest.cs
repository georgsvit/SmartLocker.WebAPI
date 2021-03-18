using System.ComponentModel.DataAnnotations;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record LockerCreateRequest(
        [Required] string Login,
        [Required] string Password
        );
}
