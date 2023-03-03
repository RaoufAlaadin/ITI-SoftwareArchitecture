using System.Numerics;

namespace _3_GameStrategy
{
    internal class Program
    {
        public static void Main()
        {
           /* Strategy Pattern: 

                We keep adding features or (Team Stratgies) smoothly without editing 
                The Team class, We just create a new sub-class that inherites from TeamStrategy
                Then we pass an object from it to the setStrategy() that is inside the Team class.

                Remember the Duck Example with the quack and fly. 

            */


            // create a new team
            Team team = new Team();

            // set initial strategy to attack
            team.SetStrategy(new AttackStrategy());

            // play game with attack strategy
            team.PlayGame();

            // change strategy to defend
            team.SetStrategy(new DefendStrategy());

            // play game with defend strategy
            team.PlayGame();

            Console.ReadKey();
        }


    }
}