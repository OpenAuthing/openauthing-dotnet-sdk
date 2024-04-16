using BeniceSoft.OpenAuthing.AspNetCore.Authorization;
using BeniceSoft.OpenAuthing.AspNetCore.Permissions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace BeniceSoft.OpenAuthing.AspNetCore;

public static class OpenAuthingBuilderExtensions
{
    public static OpenAuthingBuilder AddAuthentication(this OpenAuthingBuilder builder)
    {
        return builder.AddAuthentication(x => { });
    }

    public static OpenAuthingBuilder AddAuthentication(this OpenAuthingBuilder builder, Action<JwtBearerOptions> configure)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = OpenAuthingConstants.ApplicationScheme;
            options.DefaultChallengeScheme = OpenAuthingConstants.ApplicationScheme;
        }).AddJwtBearer(OpenAuthingConstants.ApplicationScheme, x =>
        {
            x.IncludeErrorDetails = true;
            x.RequireHttpsMetadata = false;
            x.UseSecurityTokenValidators = false;
            x.Audience = "OpenAuthing";
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidAudiences = ["OpenAuthing"],
                RequireExpirationTime = true,
                RequireAudience = false,
                SignatureValidator = (token, _) => new JsonWebToken(token)
            };
            configure(x);
        });
        return builder;
    }

    public static OpenAuthingBuilder AddAuthorization(this OpenAuthingBuilder builder,
        Action<OpenAuthingAuthorizationBuilder>? configure = null)
    {
        builder.Services.AddAuthorizationCore();
        builder.Services.Replace(ServiceDescriptor.Transient<IAuthorizationPolicyProvider, OpenAuthingAuthorizationPolicyProvider>());

        configure?.Invoke(new OpenAuthingAuthorizationBuilder(builder));
        
        return builder;
    }

    public static OpenAuthingBuilder AddCurrentUserPermissionProvider<T>(this OpenAuthingBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Transient)
        where T : class, ICurrentUserPermissionProvider, new()
    {
        builder.Services.Add(new ServiceDescriptor(typeof(ICurrentUserPermissionProvider), typeof(T), lifetime));
        return builder;
    }
}