namespace Kmakai.MemoryGame.Client.Models;

public class Card
{
    public string Image { get; set; } = "";
    public string Name { get; set; } = "";
    public bool IsFlipped { get; set; } = false;
    public bool IsMatched { get; set; } = false;
}
