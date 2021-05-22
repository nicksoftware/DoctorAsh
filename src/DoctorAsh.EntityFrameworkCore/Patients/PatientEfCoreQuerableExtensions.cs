using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DoctorAsh.Patients
{
    public static class PatientEfCoreQueryableExtensions
    {
        public static IQueryable<Patient> IncludeDetails(this IQueryable<Patient> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}