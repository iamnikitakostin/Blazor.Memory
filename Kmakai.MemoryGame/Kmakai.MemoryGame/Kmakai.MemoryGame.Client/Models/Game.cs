namespace Kmakai.MemoryGame.Client.Models;

public interface IGame
{
    int Id { get; set; }
    GameDifficulty GameDifficulty { get; set; }
    DateTime Date { get; set; }
}

public interface IScoredGame
{
    DateTime Date { get; set; }
    int Score { get; set; }
}

public interface ITimedGame
{
    DateTime Date { get; set; }
    TimeSpan Duration { get; set; }
}

public class NormalGame: IGame, ITimedGame
{
    public int Id { get; set; }
    public GameDifficulty GameDifficulty { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
}



public class RaceGame: IGame, IScoredGame, ITimedGame
{
    public int Id { get; set; }
    public GameDifficulty GameDifficulty { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
    
    public int Score { get; set; }
    public int TimeLimit { get; set; }
}

public class MovesGame: IGame, IScoredGame
{
    public int Id { get; set; }
    public GameDifficulty GameDifficulty { get; set; }
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public int Moves { get; set; }
    public int MovesLimit { get; set; }
}
