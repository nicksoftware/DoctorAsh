using Volo.Abp.Modularity;

namespace DoctorAsh
{
    [DependsOn(
        typeof(DoctorAshApplicationModule),
        typeof(DoctorAshDomainTestModule)
        )]
    public class DoctorAshApplicationTestModule : AbpModule
    {

    }
}