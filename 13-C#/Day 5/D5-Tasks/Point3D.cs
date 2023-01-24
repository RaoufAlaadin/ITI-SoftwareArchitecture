using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D5_Tasks
{
    class Point3D
    {
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double ZPos { get; set; }


         /*this would know which constructor it's calling based on the number of inputs.
           here we are using the constructor with the most available inputs so it make it easier to create others. 

        if we have 3 constructors and one of them takes 2 inputs, we would still chain the 3 input constructor 
         and take only one of it which the current constructor didn't give value to. 

         */
        public Point3D() : this(0, 0, 0)
        {
        }

        public Point3D(double x, double y, double z)
        {
            XPos = x;
            YPos = y;
            ZPos = z;
        }



        //public static explicit operator Point(Point3D p)
        //{
        //    return new Point() { X = Convert.ToInt32(p.XPos), Y = Convert.ToInt32(p.YPos) };

        //}

        public override string ToString()
        {
            return $"Point Coordinates : ({XPos},{YPos},{ZPos}) ";
        }



        public static explicit operator string (Point3D p)
        {
            return p.ToString();
        }


        public static bool operator ==(Point3D left, Point3D right)
        {
            if (left is null || right is null) return false;
            return (left.XPos == right.XPos) && (left.YPos == right.YPos) && (left.ZPos == right.ZPos);
        }

        public static bool operator !=(Point3D left, Point3D right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            // 1- this casts the obj as Point3D *if possible* due to "as"
            //     if not possible ==> is gives a null value with no errors 
            Point3D right = obj as Point3D;
            

            // 2- if the previous value resulted in null, then this is going to be our exit.
            if (right == null) return false;

            /*3- we check for the type in the system, to make sure we are not comparing point and Point3D
              note that: doesn't matter what cast you did, the orignial type is still still 
             stored in the meta data where GetType() checks 
            */
            if (this.GetType() != right.GetType()) return false;


            /* 4- this checks the identity, so if I am sending  2 refrences to the same object
                  I will get a quick responce with *equal* 
            */
            if (object.ReferenceEquals(this, right)) return true;

            /* we are not static, so we have this. , that's why we only need single input*/
            return (XPos == right.XPos) && (YPos == right.YPos) && (ZPos == right.ZPos);

        }



        public static Point3D ReadPoint()
        {
            double x, y, z;
            string[] input;
            do
            {
                Console.WriteLine("Enter XPos/YPos/ZPos in the same format ==> Example: 2/4/6");


                    /*  1- we split the input into our string array 
                        2- we check a) the array length is correct ==> ensures correct format 
                                    b) we check each input that it can be converted to double,
                                        to validate each input.
                                        as we might getsomething like ==>  sada/aaa/mmm
                                */

                input = Console.ReadLine().Split('/');



                if (input.Length != 3 ||
                    !double.TryParse(input[0], out x) ||
                    !double.TryParse(input[1], out y) ||
                    !double.TryParse(input[2], out z))
                {
                    Console.WriteLine("Invalid input. Please enter three numbers separated by spaces.");
                }



            } while (input.Length != 3 ||
                     !double.TryParse(input[0], out x) ||
                     !double.TryParse(input[1], out y) ||
                     !double.TryParse(input[2], out z));

            return new Point3D(x, y, z);
        }



    }
}
