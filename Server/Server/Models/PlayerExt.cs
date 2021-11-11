using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class PlayerExt
    {
        [DisplayName("Player ID")]
        public int Pid { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        [DisplayName("Games Count")]
        public int GameCount { get; set; }
    }
}
