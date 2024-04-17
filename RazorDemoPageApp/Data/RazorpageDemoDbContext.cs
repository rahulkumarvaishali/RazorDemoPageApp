using Microsoft.EntityFrameworkCore;
using RazorDemoPageApp.Models.Domain;

namespace RazorDemoPageApp.Data
{
    public class RazorpageDemoDbContext : DbContext
    {
        public RazorpageDemoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MessageFromWeb> MessageFromWebs { get; set; }
    }
}
