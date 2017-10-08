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
        }
        
        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Director> Directors { get; set; }
    }
    
}