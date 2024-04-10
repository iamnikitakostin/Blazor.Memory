using BlazorCardGame.Models;

namespace BlazorCardGame.Data;

public class Seeder
{
    private readonly CardGameDb _gameDb;
    public Seeder(CardGameDb db)
    {
        _gameDb = db;
    }

    public async Task SeedDb ()
    {
        Random random = new Random();
        List<Cardgame> cards = new List<Cardgame>();
        for(int i=0;i<20;i++)
        {
            var game = new Cardgame()
            {
                GameDate = DateTime.Now - TimeSpan.FromDays(random.Next(1, 300)),
                GameTime = random.Next(20, 200),
                GameType = "Classic",
                PairsInMinute = random.Next(3, 12)
            };
            cards.Add(game);
        }
        await _gameDb.AddRangeAsync(cards);
    }
}
