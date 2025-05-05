
using MeasurementManagement.BC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeasurementManagement.DA.Config
{
    public class MeasurementManagementContext : DbContext
    {
        public MeasurementManagementContext(DbContextOptions<MeasurementManagementContext> options) : base(options) { }
        public DbSet<Measure> Measure { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
