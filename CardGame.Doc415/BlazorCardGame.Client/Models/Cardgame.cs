using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCardGame.Client.Models;


public class Cardgame
{

    public int ID { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime GameDate { get; set; }
    [Required, Range(0, int.MaxValue)]
    public int GameTime { get; set; }
    public string GameType { get; set; }
    [Column(TypeName = "decimal(18, 6)")]
    public decimal PairsInMinute { get; set; }
}

