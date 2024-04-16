using Microsoft.Extensions.Options;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization.Permissions;

public class HttpClientCurrentUserPermissionProvider : ICurrentUserPermissionProvider
{
    private readonly OpenAuthingOptions _options;
    private readonly HttpClient _http;

    public HttpClientCurrentUserPermissionProvider(
        IOptions<OpenAuthingOptions> options, HttpClient http)
    {
        _http = http;
        _options = options.Value;
    }
    
    public Task<ICurrentUserPermission> GetAsync(Guid userId, string permissionSpaceId)
    {
        throw new NotImplementedException();
    }
}