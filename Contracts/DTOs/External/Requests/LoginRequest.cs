using System.ComponentModel.DataAnnotations;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record LoginRequest(
        [Required] string Login,
        [Required] string Password
        );
}
