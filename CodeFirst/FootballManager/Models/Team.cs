using System.Collections.Generic;

namespace FootballManager.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }

        public string Name { get; set; }
        
        public ICollection<Player> Players { get; set; }

        public ICollection<League> Leagues { get; set; }

    }
}
