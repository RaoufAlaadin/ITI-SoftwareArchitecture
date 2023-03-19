using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerOrder.Models
{
    public class Order
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Total price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Total price must be greater than or equal to 0")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }

        // Set as virtual to activate lazyLoading
        public virtual Customer Customer { get; set; }
    }
}