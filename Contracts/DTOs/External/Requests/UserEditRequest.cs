namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record UserEditRequest(
        string FirstName,
        string LastName,
        string Role,
        int AccessLevel,
        string Login,
        string Password
        );
}