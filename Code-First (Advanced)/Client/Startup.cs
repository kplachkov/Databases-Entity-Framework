namespace Client
{
    using Data;
    using Models;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new MoviesContext();

            context.Database.Initialize(true);
            
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
        }
    }
}
