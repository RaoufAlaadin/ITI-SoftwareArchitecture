using System.Numerics;

namespace _2_GameObserver
{
    internal class Program
    {
        public static void Main()
        {


              /* Observer pattern: 
              
               Publishers and subscribers.  
               */
            // Create a football object
            Football football = new Football();

            // Create some observers
            Player player1 = new Player();
            Player player2 = new Player();
            Referee referee = new Referee();

            // Attach the observers to the football object
            football.AttachObserver(player1);
            football.AttachObserver(player2);
            football.AttachObserver(referee);

            Position newPosition = new Position { X = 10, Y = 20, Z = 0 };
            football.SetBallPosition(newPosition);

            Console.ReadKey();
        }


    }
}