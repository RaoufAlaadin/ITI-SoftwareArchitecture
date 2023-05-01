using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Task01.CarWithMVVM.Command;
using WPF.Task01.CarWithMVVM.Model;

namespace WPF.Task01.CarWithMVVM.ViewModel
{
    public class AddCarViewModel
    {
        public ObservableCollection<Car> CarsList { get; set; } 

        public ICommand AddCarCommandProp { get; set; }    

        public Car NewCar { get; set; } 

        public AddCarViewModel() {

            AddCarCommandProp = new AddCarCommand(AddCar, CanAddCar);

            NewCar = new Car() {
                Id = 1,
                Name = "Civic",
                Description = "A reliable and fuel-efficient sedan",
                Manufacturer = "Honda",
                Price = 20000.00m
            };

            CarsList = new ObservableCollection<Car>()
            {
                new Car() { Id = 1, Name = "Civic", Description = "A reliable and fuel-efficient sedan", Manufacturer = "Honda", Price = 20000.00m },
                new Car() { Id = 2, Name = "Corolla", Description = "A practical and spacious sedan", Manufacturer = "Toyota", Price = 22000.00m },
                new Car() { Id = 3, Name = "Model 3", Description = "An electric luxury sedan with impressive performance", Manufacturer = "Tesla", Price = 40000.00m },
                new Car() { Id = 4, Name = "Mustang", Description = "A classic American muscle car with a powerful V8 engine", Manufacturer = "Ford", Price = 35000.00m },
                new Car() { Id = 5, Name = "Challenger", Description = "A retro-styled muscle car with a spacious interior", Manufacturer = "Dodge", Price = 30000.00m }
            };


        }

        private bool CanAddCar(object obj)
        {
            return true; 
        }

        private void AddCar(object obj)
        {

            CarsList.Add(obj as Car);

            MessageBox.Show("Card Added");
        }
    }
}
