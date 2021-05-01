using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DoctorAsh.EntityFrameworkCore
{
    [DependsOn(
        typeof(DoctorAshEntityFrameworkCoreModule)
        )]
    public class DoctorAshEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DoctorAshMigrationsDbContext>();
        }
    }
}
