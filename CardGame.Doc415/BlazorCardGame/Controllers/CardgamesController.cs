using BlazorCardGame.Data;
using BlazorCardGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BlazorCardGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardgamesController : ControllerBase
    {
        private readonly CardGameDb _context;
        private readonly Seeder _seeder;
        public CardgamesController (CardGameDb context, Seeder seeder)
        {
            _context = context;
            _seeder = seeder;
            _seeder.SeedDb().Wait();
        }



        [HttpGet]
        public async Task<List<Cardgame>> GetGames ([FromQuery] string? dateS, [FromQuery] string? dateE)
        {
            if (dateS != null || dateE != null)
            {
                DateTime dateStart = DateTime.ParseExact(dateS, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime dateEnd = DateTime.ParseExact(dateE, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                return await _context.Games.Where(x => x.GameDate < dateEnd && x.GameDate > dateStart).ToListAsync();
            }
            else
            {
                return await _context.Games.ToListAsync();
            }
        }

        // GET: api/Cardgames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cardgame>> GetCardgame (int id)
        {
            var cardgame = await _context.Games.FindAsync(id);

            if (cardgame == null)
            {
                return NotFound();
            }

            return cardgame;
        }

        // PUT: api/Cardgames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardgame (int id, Cardgame cardgame)
        {
            if (id != cardgame.ID)
            {
                return BadRequest();
            }

            _context.Entry(cardgame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardgameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cardgames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task PostCardgame (Cardgame cardgame)
        {
            try
            {
                _context.Games.Add(cardgame);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }


        }

        // DELETE: api/Cardgames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardgame (int id)
        {
            var cardgame = await _context.Games.FindAsync(id);
            if (cardgame == null)
            {
                return NotFound();
            }

            _context.Games.Remove(cardgame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardgameExists (int id)
        {
            return _context.Games.Any(e => e.ID == id);
        }
    }
}
