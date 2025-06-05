using System.ComponentModel.DataAnnotations;

namespace Blazor.Memory.Models;

public class Settings
{
    public int Id { get; set; }
    [Required]
    [Range(4,32)]
    public int CardsNumber { get; set; } = 18;
}
