

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        public string Value { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
