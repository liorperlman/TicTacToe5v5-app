using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Game
    {
        [DisplayName("Game Id")]
        public int Id { get; set; }
        
        [DisplayName("Player Id")]
        public int PlayerId { get; set; }
        public DateTime Date { get; set; }
        
        public string Result { get; set; }

        public Game()
        {
            
            Date = DateTime.Now;
            Result = "Game not over";
        }
        
    }

}
