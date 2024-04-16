using BeniceSoft.OpenAuthing.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;

namespace BeniceSoft.OpenAuthing.AspNetCore;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseOpenAuthing(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseOpenAuthingAuthorization();

        return app;
    }

    private static IApplicationBuilder UseOpenAuthingAuthorization(this IApplicationBuilder app)
    {
        VerifyServicesRegistered(app);

        return app.UseAuthorization();
    }

    private static void VerifyServicesRegistered(IApplicationBuilder app)
    {
        // if (app.ApplicationServices.GetService(typeof (AuthorizationPolicyMarkerService)) == null)
        //     throw new InvalidOperationException(Microsoft.AspNetCore.Authorization.Policy.Resources.FormatException_UnableToFindServices((object) "IServiceCollection", (object) "AddAuthorization"));
    }
}