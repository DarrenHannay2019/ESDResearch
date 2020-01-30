using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FutureAPIv1;

namespace FutureAPIv1.Data
{
    public class FutureAPIv1Context : DbContext
    {
        public FutureAPIv1Context (DbContextOptions<FutureAPIv1Context> options)
            : base(options)
        {
        }

        public DbSet<FutureAPIv1.Polygons> Polygons { get; set; }

        public DbSet<FutureAPIv1.PolygonPoints> PolygonPoints { get; set; }
    }
}
