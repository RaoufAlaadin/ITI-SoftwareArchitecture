using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDay03
{
    public class Student
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }

        public String ImagePath { get; set; }

        public override string ToString()
        {
            return $"Name:{ Name}";
        }
    }
}
