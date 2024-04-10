namespace BlazorCardGame.Client.Model;

public class Card
{
    public int Id { get; set; }
    public int Value { get; set; }
    public string Image { get; set; }
    public string SecretImage { get; set; }
    public string BackImage { get; set; }
    public bool isTurnedOn { get; set; }
    public bool isPaired { get; set; }

}
