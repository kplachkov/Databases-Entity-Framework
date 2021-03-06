﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Movie
    {
        public Movie()
        {
            this.Actors = new HashSet<Actor>();
            this.Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public int ReleaseYear { get; set; }

        public float Rating { get; set; }

        public int DirectorId { get; set; }

        public ushort Duration { get; set; }

        public Studio Studio { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

    }
}
