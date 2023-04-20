using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinglaRDemoReaouf.Models
{
   
        public class Comment
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Comment text is required.")]
            [StringLength(500, ErrorMessage = "Comment text must be between 2 and 500 characters.", MinimumLength = 2)]
            public string? Text { get; set; }

            [Required(ErrorMessage = "Username is required.")]
            [StringLength(100, ErrorMessage = "Username must be between 2 and 100 characters.", MinimumLength = 2)]
            public string? Username { get; set; }

            [Required(ErrorMessage = "Product ID is required.")]

            // This states that this property is connect to the 
            // primary key of the navigational property we write it's name here.
            [ForeignKey("Product")]
            public int ProductId { get; set; }

            public virtual Product? Product { get; set; }
        }
    
}
