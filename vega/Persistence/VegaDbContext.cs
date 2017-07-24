using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Presistence
{
    public class VegaDbContext: DbContext {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {
        }

        public DbSet<Maker> Makers { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}