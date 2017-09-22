using System.Collections.Generic;

namespace FootballManager.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        public string Name { get; set; }
        
        public ICollection<Player> Players { get; set; }


    }
}
