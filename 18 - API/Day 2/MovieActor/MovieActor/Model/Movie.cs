using System.ComponentModel.DataAnnotations;

namespace MovieActor.Model
{

    public enum MovieType
    {
        Action,
        Comedy,
        Drama,
        Horror,
        Romance,
        Crime,
        Western
    }

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public MovieType Type { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Duration must be a positive number")]
        public int Duration { get; set; }

        [Range(0, 10, ErrorMessage = "Rate must be between 0 and 10")]
        public double Rate { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        public string Producer { get; set; }

        // Foreign key for Actor
        //public int ActorId { get; set; }

        // Navigation property for Actor
        public virtual ICollection<Actor>? Actors { get; set; }
    }

}
