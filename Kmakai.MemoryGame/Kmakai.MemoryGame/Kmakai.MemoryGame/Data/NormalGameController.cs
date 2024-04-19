using Kmakai.MemoryGame.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Kmakai.MemoryGame.Data;

[Route("api/[controller]")]
[ApiController]
public class NormalGameController : ControllerBase
{
    private readonly GameContext _context;
    public NormalGameController(GameContext context)
    {
        _context = context;
    }
    // GET: api/<NormalGameController>
    [HttpGet]
    public async Task<List<NormalGame>> Get()
    {
        return await _context.NormalGames.ToListAsync();
    }

    // GET api/<NormalGameController>/5
    [HttpGet("{id}")]
    public async Task<NormalGame?> Get(int id)
    {
        return await _context.NormalGames.FindAsync(id);
    }

    // POST api/<NormalGameController>
    [HttpPost]
    public async Task Post([FromBody] NormalGame value)
    {
        await _context.NormalGames.AddAsync(value);
        await _context.SaveChangesAsync();
    }

    // DELETE api/<NormalGameController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var game = await _context.NormalGames.FindAsync(id);
        if (game == null)
        {
            return;
        }
        _context.NormalGames.Remove(game);
        await _context.SaveChangesAsync();
    }
}
