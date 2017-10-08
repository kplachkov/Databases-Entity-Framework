using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int ReleaseYear { get; set; }

        public float Rating { get; set; }

        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

    }
}
