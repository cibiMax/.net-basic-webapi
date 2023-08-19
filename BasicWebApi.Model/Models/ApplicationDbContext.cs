


using basicwebapi;
using Microsoft.EntityFrameworkCore;

namespace basicwebapi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }
    }
}
