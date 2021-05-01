using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DoctorAsh.Data
{
    /* This is used if database provider does't define
     * IDoctorAshDbSchemaMigrator implementation.
     */
    public class NullDoctorAshDbSchemaMigrator : IDoctorAshDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}