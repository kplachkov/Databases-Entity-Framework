

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
