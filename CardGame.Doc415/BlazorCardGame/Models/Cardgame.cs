using System.ComponentModel.DataAnnotations;

namespace BlazorCardGame.Models;

public class Cardgame
{
    [Key]
    public int ID { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime GameDate { get; set; }
    [Required, Range(0, int.MaxValue)]
    public int GameTime { get; set; }
    public string GameType { get; set; }
    public decimal PairsInMinute { get; set; }
}
