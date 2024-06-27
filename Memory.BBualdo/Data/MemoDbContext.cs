using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class MemoDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Game> Games { get; set; }
}