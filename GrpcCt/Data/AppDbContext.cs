using GrpcCt.Models;
using Microsoft.EntityFrameworkCore;

namespace GrpcCt.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> o) : base(o) { }

    public DbSet<Model> Models { get; set; } = null!;
}