using Kmakai.MemoryGame.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace Kmakai.MemoryGame.Data;

public class GameContext: DbContext
{
    public GameContext(DbContextOptions<GameContext> options): base(options)
    {
    }

    public DbSet<NormalGame> NormalGames { get; set; }
    public DbSet<RaceGame> RaceGames { get; set; }
    public DbSet<MovesGame> MovesGames { get; set; }
}
