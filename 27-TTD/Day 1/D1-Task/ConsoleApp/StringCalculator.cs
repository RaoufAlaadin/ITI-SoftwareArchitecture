using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class StringCalculator
    {

        #region Version1

        /*  public static int Add(string numbers)
          {

              return 0;
          } */
        #endregion


        #region Version2

    /*    public static int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
                return 0;

            return int.Parse(numbers);
        }*/
        #endregion

        #region Version3

      /*  public static int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
                return 0;

            var stringNumbers = numbers.Split(',');

            return stringNumbers.Select(int.Parse).Sum();
        }*/
        #endregion


        #region Version4

     /*   public static int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
                return 0;

            // use '' instead of "" to show that it's a signle char.
            var delimiters = new[] { ',','\n' };

            var stringNumbers = numbers.Split(delimiters);

            return stringNumbers.Select(int.Parse).Sum();
        }*/
        #endregion

        #region Version5

        public static int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
                return 0;

            // use '' instead of "" to show that it's a signle char.
            var delimiters = new[] { ',', '\n' };

            var stringNumbers = numbers.Split(delimiters);

            // To check for negative numbers first. 

            var intNumbers = stringNumbers.Select(int.Parse).ToArray();

            var negatives = intNumbers.Where( x => x < 0 ).ToArray();

            if (negatives.Any()) {
            
                throw new ArgumentException($"Negatives not allowed: {String.Join(", ",negatives)}");    
            }


            return intNumbers.Sum();
        }
        #endregion

        // the below is the run , didn't create a program.cs

    }
}
