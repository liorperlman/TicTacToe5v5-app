using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly Server.Data.ApplicationDbContext _context;

        public CreateModel(Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        /*public IActionResult OnGet()
        {
            return Page();
        }*/

        [BindProperty]
        public Game Game { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Game.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public IList<Player> players { get; set; }
        public string playerEmail { get; set; }

        public async Task OnGetAsync()
        {

            players = await _context.Player.ToListAsync();
        }
    }
}
