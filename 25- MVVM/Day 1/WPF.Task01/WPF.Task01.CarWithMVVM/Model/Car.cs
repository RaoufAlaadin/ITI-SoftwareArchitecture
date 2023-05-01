﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Task01.CarWithMVVM.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string? Name { get; set; }    

        public string? Description { get; set; }    

        public string? Manufacturer { get; set; } 

        public decimal Price { get; set; }      


    }
}
