using Microsoft.EntityFrameworkCore;
using SollicitatieTracker.Models;

namespace SollicitatieTracker.Data
{
    public class SollicitatieTrackerContext : DbContext
    {
        public SollicitatieTrackerContext(DbContextOptions<SollicitatieTrackerContext> options) : base(options)
        {
        }

        public DbSet<Sollicitatie> Sollicitaties { get; set; }
    }
}