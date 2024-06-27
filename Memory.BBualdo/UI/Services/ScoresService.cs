using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace UI.Services;

public class ScoresService(MemoDbContext dbContext) : IScoresService
{
  private readonly MemoDbContext _dbContext = dbContext;

  public async Task<List<Game>> GetGameScoresAsync()
  {
    return await _dbContext.Games.ToListAsync();
  }

  public async Task AddGameScoreAsync(Game game)
  {
    await _dbContext.Games.AddAsync(game);
    await _dbContext.SaveChangesAsync();
  }

  public async Task DeleteGameScoreAsync(Game game)
  {
    _dbContext.Games.Remove(game);
    await _dbContext.SaveChangesAsync();
  }
}