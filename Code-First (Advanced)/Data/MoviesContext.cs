namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class MoviesContext : DbContext
    {
        
        public MoviesContext()
            : base("name=MoviesContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MoviesContext>());
            // DropCreateDatabaseAlways - Drops the db every time when we execute the program.
            // CreateDatabaseIfNotExists - Default migration
            // MigrateDatabaseToLatestVersion - Uses our migrations
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesContext, Configuration>());
        }
        
        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Director> Directors { get; set; }

        public virtual DbSet<Actor> Actors { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Studio> Studios { get; set; }
    }
    
}