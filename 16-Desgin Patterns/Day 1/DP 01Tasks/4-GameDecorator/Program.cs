namespace _4_GameDecorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a field player
            FieldPlayer fieldPlayer = new FieldPlayer();

            // Assign a forward role to the field player
            Forward forward = new Forward(fieldPlayer);

            // Assign a midfielder role to the same field player
            Midfielder midfielder = new Midfielder(forward);

            // Test the player's roles

            /* Note that everytime we run .PassBall() it will tell us that we are using the FieldPlayer object.*/
            Console.WriteLine("Field player passes the ball:");
            fieldPlayer.PassBall();

            Console.WriteLine("=========================");

            Console.WriteLine("Field player plays as a forward:");
            forward.PassBall();
            forward.ShootGoal();

            Console.WriteLine("=========================");

            Console.WriteLine("Field player plays as a midfielder:");
            midfielder.PassBall();
            midfielder.Dribble();


        }

    }
}