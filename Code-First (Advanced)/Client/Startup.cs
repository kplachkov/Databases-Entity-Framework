namespace Client
{
    using Data;
    using Models;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new MoviesContext();

            context.Database.Initialize(true);

            //foreach (var director in context.Directors.ToList())
            //{
            //    Console.WriteLine($"{director.FirstName} {director.LastName}");
            //}

            context.Movies.Add(new Movie()
            {
                Title = "Contact"
            });

            context.Movies.Add(new Movie()
            {
                Title = "Interstellar"
            });

            context.Movies.Add(new Movie()
            {
                Title = "The Dark Knight Rises"
            });

            var actor1 = new Actor()
            {
                FirstName = "Matthew",
                LastName = "McConaghey"
            };

            actor1.Movies.Add(context.Movies.Where(m => m.Title == "Contact").FirstOrDefault());
            actor1.Movies.Add(context.Movies.Where(m => m.Title == "Interstellar").FirstOrDefault());

            var actor2 = new Actor()
            {
                FirstName = "Christian",
                LastName = "Bale"
            };

            actor2.Movies.Add(context.Movies.Where(m => m.Title == "The Dark Knight Rises").FirstOrDefault());
            context.Actors.AddRange(new[] { actor1, actor2 });
            
            //var movie = context.Movies
            //    .Where(m => m.Title == "Contact")
            //    .FirstOrDefault();
            //movie.Genres.Add(new Genre()
            //{
            //    Value = "Drama"
            //});
            //var studio = new Studio()
            //{
            //    Name = "Warner Bros"
            //};

            //context.Movies.FirstOrDefault(m => m.Title == "Contact").Studio = studio;
            
            context.SaveChanges();
            // Console.WriteLine(movie.Duration);
        }
    }
}
