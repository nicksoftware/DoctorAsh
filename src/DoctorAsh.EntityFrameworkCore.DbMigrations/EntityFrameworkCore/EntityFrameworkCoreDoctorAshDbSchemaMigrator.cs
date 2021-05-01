using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DoctorAsh.Data;
using Volo.Abp.DependencyInjection;

namespace DoctorAsh.EntityFrameworkCore
{
    public class EntityFrameworkCoreDoctorAshDbSchemaMigrator
        : IDoctorAshDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreDoctorAshDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the DoctorAshMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<DoctorAshMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}