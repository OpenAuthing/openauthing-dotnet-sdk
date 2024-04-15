using BeniceSoft.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace BeniceSoft.OpenAuthing.AspNetCore;

[DependsOn(
    typeof(BeniceSoftAbpAspNetCoreModule)
)]
public class OpenAuthingAspNetCoreModule : AbpModule
{
}