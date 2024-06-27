namespace UI.Models;

public class Card
{
  public int Id { get; set; }
  public string? ImagePath { get; set; }
  public bool IsRevealed { get; set; }
  public bool ShouldBeRemoved { get; set; }
}