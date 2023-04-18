
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Important for [JsonIgnore]

namespace Demo.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Manger { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
