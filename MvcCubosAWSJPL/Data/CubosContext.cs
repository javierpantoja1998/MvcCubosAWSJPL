using Microsoft.EntityFrameworkCore;
using MvcCubosAWSJPL.Models;

namespace MvcCubosAWSJPL.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options) { }

        public DbSet<Cubo> Cubos { get; set; }
    }
}
