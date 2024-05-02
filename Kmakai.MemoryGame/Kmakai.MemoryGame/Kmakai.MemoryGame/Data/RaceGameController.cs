using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kmakai.MemoryGame.Client.Models;


namespace Kmakai.MemoryGame.Data;

[Route("api/[controller]")]
[ApiController]
public class RaceGameController : ControllerBase
{
    private readonly GameContext _context;
    public RaceGameController(GameContext context)
    {
        _context = context;
    }
    // GET: api/<RaceGameController>
    [HttpGet]
    public async Task<List<RaceGame>> Get()
    {
        return await _context.RaceGames.ToListAsync();
    }

    // GET api/<RaceGameController>/5
    [HttpGet("{id}")]
    public async Task<RaceGame?> Get(int id)
    {
        return await _context.RaceGames.FindAsync(id);
    }

    // POST api/<RaceGameController>
    [HttpPost]
    public async Task Post([FromBody] RaceGame value)
    {
        await _context.RaceGames.AddAsync(value);
        await _context.SaveChangesAsync();
    }

    // DELETE api/<RaceGameController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var game = await _context.RaceGames.FindAsync(id);
        if (game == null)
        {
            return;
        }
        _context.RaceGames.Remove(game);
        await _context.SaveChangesAsync();
    }
}
