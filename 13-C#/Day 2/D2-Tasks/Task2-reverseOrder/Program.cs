using System.Collections.Generic;
using System.Security.Claims;

namespace Task2_reverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {



            /*            Given a list of space separated words, reverse the order of the words.
            Input: this is a test Output: test a is this
            Input: all your base Output: base your all
            Input: Word Output: Word
            >> Check the Split Function(Member in String Class)
            Output will be a Single Console.WriteLine Statment*/

            


            string sentence = Convert.ToString(Console.ReadLine());

            string[] str = sentence.Split(' ');

            // it's reversed in place and the method returns void, so it must be done in a separate line like this. 
            Array.Reverse(str);

            string reversedSentence = string.Join(" ", str);

            //foreach (var item in str)
            //{
            //    Console.WriteLine(item);
            //}


            Console.WriteLine(reversedSentence);

        }

    }
}