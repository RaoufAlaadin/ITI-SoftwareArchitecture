using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30 ,ErrorMessage = "must be less than 30")]
        public string Name { get; set; }    

        public decimal Price { get; set;}  


    }
}
