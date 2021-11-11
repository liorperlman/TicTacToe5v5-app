using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Pages
{
    public class Query1Model : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Query1Model(Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Game> games { get; set; }
        public IList<Player> players { get; set; }
        public Player player { get; set; }

        public async Task OnGetAsync()
        {
            games = await _context.Game.ToListAsync();
            players = await _context.Player.ToListAsync();
            //games = await _context.Game.ToListAsync(); //if something is fishy here
        }

        public async Task OnPostAsync(String playerEmail)
        {
            if (playerEmail != null)
            {
                var p =
                    from tbPlayer in _context.Player
                    where tbPlayer.Email == playerEmail
                    select tbPlayer;
                player = p.First();

                var g =
                    from tbGame in _context.Game
                    where tbGame.PlayerId == player.Id
                    orderby tbGame.Id ascending
                    select tbGame;
                games = await g.ToListAsync();
            }
            else
            {
                games = new List<Game>();
            }

        }

        public void OnGet()
        {
        }
    }
}
