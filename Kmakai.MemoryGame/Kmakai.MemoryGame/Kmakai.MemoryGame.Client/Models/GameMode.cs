namespace Kmakai.MemoryGame.Client.Models;

public enum GameMode
{
    Normal = 1,
    RaceTime = 2,
    Moves = 3
}

public enum GameDifficulty
{
    Easy = 1,
    Normal = 2,
    Hard = 3
}

public static class GameDifficultyExtensions
{
    public static int GetCardsNumber(GameDifficulty difficulty)
    {
        return difficulty switch
        {
            GameDifficulty.Easy => 8,
            GameDifficulty.Normal => 12,
            GameDifficulty.Hard => 16,
            _ => 12
        };

    }
}