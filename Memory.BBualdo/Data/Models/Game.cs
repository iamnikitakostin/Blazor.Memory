using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.Models;

public class Game
{
  public int Id { get; set; }

  [Required(ErrorMessage = "Required field.")]
  [MinLength(3, ErrorMessage = $"{nameof(Username)} must be at least 3 characters long.")]
  [StringLength(32, ErrorMessage = $"{nameof(Username)} can't be longer that 32 characters.")]
  public string? Username { get; set; }

  public DateOnly Date { get; set; }
  public int Moves { get; set; }
  public DifficultyLevels Difficulty { get; set; }
  public TimeSpan Time { get; set; }
}