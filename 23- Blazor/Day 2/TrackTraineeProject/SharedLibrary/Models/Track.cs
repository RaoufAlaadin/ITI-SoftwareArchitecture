using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SharedLibrary.Models
{
    public class Track
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Track name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Track name should be between 3 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Track description should not exceed 500 characters")]
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Trainee> Trainees { get; set; } = new HashSet<Trainee>();
    }
}