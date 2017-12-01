

namespace Data
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InitializeAndSeed : DropCreateDatabaseAlways<MoviesContext>
    {
        protected override void Seed(MoviesContext context)
        {
            // Add new movie to the DB.
            context.Movies.Add(new Movie()
            {
                Title = "Titanic",
                Genre = "Drama",
                Rating = 7.5f,
                ReleaseYear = 1996,
                Director = new Director()
                {
                    FirstName = "James",
                    LastName = "Cameron"
                }
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
