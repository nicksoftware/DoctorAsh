using System.Threading.Tasks;

namespace DoctorAsh.Data
{
    public interface IDoctorAshDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
