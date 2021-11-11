using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Server.Data;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private static List<Game> games = new List<Game>();
        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Game.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGames(int id)
        {
            Game game = await _context.Game.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGames(int id, Game games)
        {
            if (id != games.Id)
            {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost] //get new game request and create game
        public async Task<ActionResult<string>> PostGame(Game game)
        {
            _context.Game.Add(game);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetGames", new { id = game.Id }, game);
        }

        /*[Route("step/{gameId}/{CellCol}/{CellRow}/{Sign}")]
        [HttpGet] //get new game request and create game
        public ActionResult<Step> PostStepToServer(int gameId, int CellCol, int CellRow, int Sign, string endGameResult)
        {
            Game currentGame = games.Find(g => g.Id == gameId);
            Step clientStep = new Step(CellRow, CellCol, Sign, endGameResult);
            currentGame.PerformStep(clientStep);
            Step serverStep = currentGame.GetRandomStep(Game.Player.Server.ToString());
            currentGame.PerformStep(serverStep);
            return serverStep;
        }*/



        private bool GamesExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}

