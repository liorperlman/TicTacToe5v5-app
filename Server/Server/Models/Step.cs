using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Step
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Sign { get; set; }
        public string ButtenName { get; set; }
    }
}
