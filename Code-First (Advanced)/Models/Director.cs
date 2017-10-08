using System.Collections.Generic;

namespace Models
{
    public class Director
    {
        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Movie> Movies { get; set; }

    }
}
