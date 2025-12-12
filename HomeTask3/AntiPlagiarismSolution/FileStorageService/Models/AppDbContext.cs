using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<StudentWork> Works { get; set; } = null!;
}
