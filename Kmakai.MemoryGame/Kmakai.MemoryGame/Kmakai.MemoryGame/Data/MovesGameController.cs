using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kmakai.MemoryGame.Client.Models;


namespace Kmakai.MemoryGame.Data;

[Route("api/[controller]")]
[ApiController]
public class MovesGameController : ControllerBase
{
    private readonly GameContext _context;
    public MovesGameController(GameContext context)
    {
        _context = context;
    }
    // GET: api/<MovesGameController>
    [HttpGet]
    public async Task<List<MovesGame>> Get()
    {
        return await _context.MovesGames.ToListAsync();
    }

    // GET api/<MovesGameController>/5
    [HttpGet("{id}")]
    public async Task<MovesGame?> Get(int id)
    {
        return await _context.MovesGames.FindAsync(id);
    }

    // POST api/<MovesGameController>
    [HttpPost]
    public async Task Post([FromBody] MovesGame value)
    {
        await _context.MovesGames.AddAsync(value);
        await _context.SaveChangesAsync();
    }

    // DELETE api/<MovesGameController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var game = await _context.MovesGames.FindAsync(id);
        if (game == null)
        {
            return;
        }
        _context.MovesGames.Remove(game);
        await _context.SaveChangesAsync();
    }
}
