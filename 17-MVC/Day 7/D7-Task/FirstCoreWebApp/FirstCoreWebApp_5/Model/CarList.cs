using System.Collections.Generic;

namespace FirstCoreWebApp_5.Model
{
    public class CarList
    {

        public static List<Car> Cars = new List<Car>()
            {
                new Car() {Num = 1, Color = "Red", Model = "Mustang", Manufacture = "Ford"},
                new Car() {Num = 2, Color = "Blue", Model = "Civic", Manufacture = "Honda"},
                new Car() {Num = 3, Color = "White", Model = "Camry", Manufacture = "Toyota"},
                new Car() {Num = 4, Color = "Black", Model = "Accord", Manufacture = "Honda"},
                new Car() {Num = 5, Color = "Silver", Model = "Corolla", Manufacture = "Toyota"},
                new Car() {Num = 6, Color = "Green", Model = "Challenger", Manufacture = "Dodge"}
            };

    }
}
