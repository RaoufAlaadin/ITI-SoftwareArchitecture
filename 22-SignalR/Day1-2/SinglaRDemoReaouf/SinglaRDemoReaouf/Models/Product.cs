using System.ComponentModel.DataAnnotations;

namespace SinglaRDemoReaouf.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name must be between 2 and 100 characters.", MinimumLength = 2)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Product description is required.")]
        [StringLength(500, ErrorMessage = "Product description must be between 2 and 500 characters.", MinimumLength = 2)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Product price must be a positive number.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Product quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Product quantity must be a positive number.")]
        public int Quantity { get; set; }

        public string? ProductImage { get;set;}

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
