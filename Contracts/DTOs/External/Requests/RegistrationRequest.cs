using System.ComponentModel.DataAnnotations;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record RegistrationRequest(
        [Required]string Login,
        [Required]string Password,
        [Required]string FirstName,
        [Required]string LastName,
        [Required]string Role,
        [Required]int AccessLevel
        );
}
