using DoctorAsh.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace DoctorAsh.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(DoctorAshEntityFrameworkCoreDbMigrationsModule),
        typeof(DoctorAshApplicationContractsModule)
        )]
    public class DoctorAshDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
