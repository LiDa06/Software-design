using Microsoft.EntityFrameworkCore;
namespace FileAnalysisService.Models;
public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<Report> Reports { get; set; } = null!;
}
