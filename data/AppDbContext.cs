using BestPracticeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BestPracticeApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}