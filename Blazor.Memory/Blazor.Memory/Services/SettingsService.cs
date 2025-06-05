using Blazor.Memory.Data;
using Blazor.Memory.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Memory.Services;

public class SettingsService
{
    private MemoryContext _context { get; set; }

    public SettingsService(MemoryContext context)
    {
        _context = context;
    }

    public async Task<Settings> GetSettingsAsync()
    {
        return await _context.Set<Settings>().FirstOrDefaultAsync() ?? new Settings();
    }

    public async Task<bool> UpdateAsync(Settings newSettings)
    {
        try
        {
            var settings = await _context.Set<Settings>().FirstOrDefaultAsync();
            if (settings == null)
            {
                settings = new Settings();
                await _context.Set<Settings>().AddAsync(settings);
            }
            settings.CardsNumber = newSettings.CardsNumber;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
