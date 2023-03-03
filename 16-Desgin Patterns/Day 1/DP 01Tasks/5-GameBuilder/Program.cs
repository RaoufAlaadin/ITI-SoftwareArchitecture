namespace _5_GameBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Create an object from our new class with the required stadium features*/
            var builder = new ConcreteGroundBuilder();
             /* Create a project Director for our specific ground*/
            var director = new Director(builder);
            /*This will activate all the overriden methods in the ConcreteGroundBuilder class*/
            director.ConstructGround();
            /* ground have the main 3 details we are building (Gallery,GroundSurface,Audience)*/
            var ground = builder.GetGround();
            Console.WriteLine($"Gallery: {ground.Gallery}, Ground Surface: {ground.GroundSurface}, Audience: {ground.Audience}");

            Console.ReadKey();

        }
    }
}