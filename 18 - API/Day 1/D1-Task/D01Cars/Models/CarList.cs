namespace D01Cars.Models
{
    public class CarList
    {
        public static List<car> cars = new List<car>()
        {
            new car (){Id=1 , Name ="Car1", Model="BMW"},
            new car (){Id=2 , Name ="Car2", Model="Ford"},
            new car (){Id=3 , Name ="Car3", Model="Honda"}
        };
    }
}
