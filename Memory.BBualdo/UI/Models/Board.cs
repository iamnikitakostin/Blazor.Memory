using Data.Enums;

namespace UI.Models;

public class Board
{
  public Board(DifficultyLevels difficultyLevel)
  {
    Size = difficultyLevel switch
    {
      DifficultyLevels.Easy => 4,
      DifficultyLevels.Hard => 16,
      _ => 8
    };

    for (var i = 0; i < Size; i++)
    {
      var card1 = new Card
      {
        Id = i,
        ImagePath = $"/images/{i + 1}.png"
      };
      var card2 = new Card
      {
        Id = i,
        ImagePath = card1.ImagePath
      };

      Cards.Add(card1);
      Cards.Add(card2);
    }

    // Randomly sorting cards
    Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
  }

  public double Size { get; set; }
  public List<Card> Cards { get; set; } = [];
}