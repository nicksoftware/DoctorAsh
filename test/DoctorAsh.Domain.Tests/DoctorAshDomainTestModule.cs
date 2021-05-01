using DoctorAsh.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DoctorAsh
{
    [DependsOn(
        typeof(DoctorAshEntityFrameworkCoreTestModule)
        )]
    public class DoctorAshDomainTestModule : AbpModule
    {

    }
}