using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Player
    {
        [DisplayName("Player Id")]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 7, ErrorMessage = "*Email adress must contain 7-30 letters")]
        [Required(ErrorMessage = "Valid email adress is mandatory")]
        public string Email { get; set; }
       
        [StringLength(20, MinimumLength = 3, ErrorMessage = "*Password must contain 3-20 letters")]
        [Required(ErrorMessage = "password is mandatory")]
        public string Password { get; set; }

        [Display(Name = "Games Played")]
        private int GamesPlayed { get; set; }

        public ICollection<Game> Games { get; set; }

        public Player()
        {
            GamesPlayed = 0;
        }
    }
}
