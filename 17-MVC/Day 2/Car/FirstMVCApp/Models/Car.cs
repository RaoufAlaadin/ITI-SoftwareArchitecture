using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVCApp.Models
{
    public class Car
    {

        public int Num { get; set; }
        public string Color { get; set; }    
        public string Model { get; set; }
        public string Manufacture { get; set; }

        //public override string ToString()
        //{
        //    return $"ID: {Id},Name:{Name},Age:{Age},Email:{Email}";
        //}
    }
}