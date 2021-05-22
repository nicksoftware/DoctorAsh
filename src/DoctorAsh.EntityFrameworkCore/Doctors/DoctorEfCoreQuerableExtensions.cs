using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DoctorAsh.Doctors
{
    public static class DoctorEfCoreQueryableExtensions
    {
        public static IQueryable<Doctor> IncludeDetails(this IQueryable<Doctor> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable.IncludeDetails();
                // .Include(x => x.xxx) // TODO: AbpHelper generated
        }
    }
}