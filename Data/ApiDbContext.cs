using Microsoft.EntityFrameworkCore;
using StructSureBackend.Models;
using Microsoft.Extensions.DependencyInjection;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Puncture> Punctures { get; set; }
}
