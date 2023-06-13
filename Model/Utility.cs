using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Projekt_WPF_EF_PraktykiStudenckie.Model
{
    public static class Utility
    {
        public static int GetNextId<T>(this DbSet<T> dataSet) where T : class
        {
            var id = 0;
            if (!dataSet.Any()) return id;

            id = (int)(dataSet.Max(x => x.GetType().GetProperty("Id") != null ? (int)x.GetType().GetProperty("Id").GetValue(x) : null) + 1);

            return id;
        }

    }

}
