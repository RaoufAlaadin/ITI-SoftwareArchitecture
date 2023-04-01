using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MovieActor.Model
{
    public class MovieActorDbContext : DbContext
    {
        public MovieActorDbContext(DbContextOptions<MovieActorDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }


        /* Will store enums as strings in the database.*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Type)
                .HasConversion(new EnumToStringConverter<MovieType>());

            modelBuilder.Entity<Actor>()
                .Property(a => a.Gender)
                .HasConversion(new EnumToStringConverter<Gender>());
        }
    }
}
