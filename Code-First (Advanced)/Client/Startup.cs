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

            foreach (var director in context.Directors.ToList())
            {
                Console.WriteLine($"{director.FirstName} {director.LastName}");
            }

        }
    }
}
