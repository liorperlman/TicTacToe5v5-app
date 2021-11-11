using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Pages
{
    public class SpecificPlayerGamesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public string playerEmail { get; set; }

        public SpecificPlayerGamesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Player> players { get; set; }

        public async Task OnGetAsync()
        {

            players = await _context.Player.ToListAsync();
        }

        
    }
}
