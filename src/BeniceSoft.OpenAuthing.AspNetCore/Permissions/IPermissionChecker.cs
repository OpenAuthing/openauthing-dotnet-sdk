using System.Security.Claims;

namespace BeniceSoft.OpenAuthing.AspNetCore.Permissions;

public interface IPermissionChecker
{
    Task<bool> IsGrantedAsync(ClaimsPrincipal? claimsPrincipal,string name);
    
    Task<MultiplePermissionGrantResult> IsGrantedAsync(ClaimsPrincipal? claimsPrincipal,string[] names);
}

public enum PermissionGrantResult
{
    Undefined,
    Granted,
    Prohibited
}

public class MultiplePermissionGrantResult
{
    public bool AllGranted
    {
        get { return Result.Values.All(x => x == PermissionGrantResult.Granted); }
    }

    public bool AllProhibited
    {
        get { return Result.Values.All(x => x == PermissionGrantResult.Prohibited); }
    }

    public Dictionary<string, PermissionGrantResult> Result { get; }

    public MultiplePermissionGrantResult()
    {
        Result = new Dictionary<string, PermissionGrantResult>();
    }

    public MultiplePermissionGrantResult(string[] names, PermissionGrantResult grantResult = PermissionGrantResult.Undefined)
    {
        ArgumentNullException.ThrowIfNull(names, nameof(names));

        Result = new Dictionary<string, PermissionGrantResult>();

        foreach (var name in names)
        {
            Result.Add(name, grantResult);
        }
    }
}