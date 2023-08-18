

using BasicWEbApi.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Model.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }
    }
}
