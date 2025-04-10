using Microsoft.EntityFrameworkCore;
using KnowledgePointsApp.Models;

namespace KnowledgePointsApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<KnowledgePoint> KnowledgePoints { get; set; }
    }
}