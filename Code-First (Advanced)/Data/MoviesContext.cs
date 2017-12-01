namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class MoviesContext : DbContext
    {
        
        public MoviesContext()
            : base("name=MoviesContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MoviesContext>());
            //DropCreateDatabaseAlways - Drops the db every time when we execute the program.
            // CreateDatabaseIfNotExists - Default migration
            // MigrateDatabaseToLatestVersion - Uses our migrations
        }
        
        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Director> Directors { get; set; }
    }
    
}