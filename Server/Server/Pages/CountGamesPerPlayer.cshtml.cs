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
    public class CountGamesPerPlayerModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IList<Game> games { get; set; }
        public IList<Player> players { get; set; }

        public List<PlayerExt> playerExts { get; set; }
        public Dictionary<Player, List<Game>> map { get; set; }
        public List<Game> currentPlayerGames { get; set; }
        public List<String> playersList { get; set; }


        public CountGamesPerPlayerModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            games = await _context.Game.ToListAsync();
            players = await _context.Player.ToListAsync();
            playerExts = new List<PlayerExt>();
            currentPlayerGames = new List<Game>();
            playersList = players.Select(p => p.Email).ToList();
            map = new Dictionary<Player, List<Game>>();
            foreach (Player player in players)
            {
                int playerId = player.Id;
                int gameCount = 0;

                foreach (Game game in games)
                {
                    if (game.PlayerId.Equals(playerId))
                    {
                        gameCount++;
                        addToMap(player, game);
                    }
                }
                playerExts.Add(new PlayerExt { Pid = playerId, Email = player.Email, Password = player.Password, GameCount = gameCount });
            }

        }

        private void addToMap(Player player, Game game)
        {
            List<Game> listValue;
            if (map.TryGetValue(player, out listValue))
            {
                listValue.Add(game);
            }
            else
            {
                map.Add(player, new List<Game> { game });
            }
        }

        
    }
}
