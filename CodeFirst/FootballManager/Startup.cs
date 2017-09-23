
namespace FootballManager
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new FMContext();
            // context.Database.Initialize(true);

            context.Teams.Add(new Models.Team() { Name = "Barcelona" });
            context.SaveChanges();

        }
    }
}
