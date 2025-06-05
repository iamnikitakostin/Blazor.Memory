using Blazor.Memory.Data;
using Blazor.Memory.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Memory.Services;

public class GamesService
{
    public MemoryContext _context { get; set; }
    public GamesService(MemoryContext context)
    {
        _context = context;
    }

    public async Task<List<Game>> GetGamesAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<Game> GetGameAsync(int id)
    {
        return await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddGameAsync(Game game)
    {
        try
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    //dictionary, the first number is the index on the map, the second is the value
    public async Task<Dictionary<int, int>> GenerateGameMap()
    {
        var settings = await _context.Set<Settings>().FirstOrDefaultAsync();
        int cardsNumber = settings.CardsNumber;

        Dictionary<int, int> map = new Dictionary<int, int>();
        List<int> numbers = new List<int>();

        for(int i = 1; i <= Math.Round((double)cardsNumber/2, 1, MidpointRounding.ToEven); i++)
        {
            numbers.Add(i);
            numbers.Add(i);
        }

        for (int i = 0; i < cardsNumber; i++)
        {
            int number = numbers[Random.Shared.Next(numbers.Count)];
            map.Add(i, number);
            numbers.Remove(number);
        }

        return map;
    }

    public async Task<List<Game>> SearchGameByQueryAsync(string query)
    {
        var queryFormatted = $"%{query.ToLower()}%";

        return await _context.Games
            .Where(g => 
            EF.Functions.Like(g.Id.ToString(), queryFormatted) ||
            EF.Functions.Like(g.Duration.ToString(), queryFormatted) ||
            EF.Functions.Like(g.StartTime.ToString(), queryFormatted)
            ).ToListAsync();
    }

    public async Task<List<string>> GetReportAsync()
    {
        var games = await _context.Games.ToListAsync();
        if (games.Count == 0)
        {
            return new List<string> { "No games found." };
        }

        var report = new List<string>();
        report.Add($"Total number of games: {games.Count()}");
        report.Add($"Total games this week: {games.Where(g => g.StartTime > DateTime.Now.AddDays(-7)).Count()}.");
        report.Add($"Total games this month: {games.Where(g => g.StartTime > DateTime.Now.AddMonths(-1)).Count()}.");
        report.Add($"Total games this year: {games.Where(g => g.StartTime > DateTime.Now.AddYears(-1)).Count()}.");
        report.Add($"Average duration per game (all games): {games.Sum(g => g.Duration.Seconds) / games.Count} seconds.");

        return report;
    }
}
