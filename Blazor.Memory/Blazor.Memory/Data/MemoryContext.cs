using Blazor.Memory.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Memory.Data;

public class MemoryContext : DbContext
{
    public MemoryContext(DbContextOptions<MemoryContext> options) : base(options)
    {
    }
    public DbSet<Game> Games { get; set; }
    public DbSet<Settings> Settings { get; set; }
}