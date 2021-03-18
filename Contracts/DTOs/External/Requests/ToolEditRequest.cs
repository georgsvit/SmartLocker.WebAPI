namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record ToolEditRequest(
        string Name,
        string Description,
        string ImgUrl,
        int AccessLevel
        );
}
