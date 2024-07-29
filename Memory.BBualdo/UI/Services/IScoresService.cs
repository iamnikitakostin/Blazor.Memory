using Data.Models;

namespace UI.Services;

public interface IScoresService
{
  Task<List<Game>> GetGameScoresAsync();
  Task AddGameScoreAsync(Game game);
  Task DeleteGameScoreAsync(Game game);
}