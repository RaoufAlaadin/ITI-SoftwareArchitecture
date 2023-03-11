using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVCApp.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }    
        public int Age { get; set; }
        public string Email { get; set; }

        //public override string ToString()
        //{
        //    return $"ID: {Id},Name:{Name},Age:{Age},Email:{Email}";
        //}
    }
}