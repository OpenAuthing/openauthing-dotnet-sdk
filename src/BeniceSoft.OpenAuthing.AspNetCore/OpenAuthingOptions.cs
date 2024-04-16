namespace BeniceSoft.OpenAuthing.AspNetCore;

public class OpenAuthingOptions
{
    public string PermissionSpaceId { get; set; } = null!;

    public void Validate()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(PermissionSpaceId, nameof(PermissionSpaceId));
    }
}