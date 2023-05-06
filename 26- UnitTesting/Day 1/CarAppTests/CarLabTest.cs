using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarAppTests
{
    [TestClass]
    public class CarLabTest
    {
        #region Assert

        [TestMethod]
        public void Brake_DifferentBrakingPerCarType_notEqual()
        {
            //Arrange

            var car1 = new Car() { Type = CarType.Toyota, Velocity = 20 };

            var car2 = new Car() { Type = CarType.BMW, Velocity = 20 };

            //Act

            car1.Brake();
            car2.Brake();


            //Assert

            Assert.AreNotEqual(car1.Velocity, car2.Velocity);
        }


        [TestMethod]
        public void GetMyCar_CheckIfDataTypeIsCar_IsCarType()
        {
            //Arrange

            var Car = new Car();
            //Act

            var result = Car.GetMyCar();


            //Assert

            Assert.IsInstanceOfType(result, typeof(Car));   
        }

        [TestMethod]
        public void GetDirection_EveryCaseHaveADirection_NotNull()
        {
            //Arrange

            var Car = new Car() { 
                DrivingMode = DrivingMode.Forward 
            
            };
            //Act

            var result = Car.GetMyCar();


            //Assert

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IsStopped_Velocity0_True()
        {
            var car = new Car()
            {
                Velocity = 0
            };

            var result = car.IsStopped();

            Assert.IsTrue(result);
        }

        #endregion


        #region StringAssert


        [TestMethod]
        public void GetDirection_ChecksIfGoingInReverse_PrintReverse()
        {
            var car = new Car()
            {
                DrivingMode = DrivingMode.Reverse
            };

            var result = car.GetDirection();

            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex("Reverse"));
        }



        [TestMethod]
        public void GetDirection_ChecksIfGoingInForward_PrintForward()
        {
            var car = new Car()
            {
                DrivingMode = DrivingMode.Forward
            };

            var result = car.GetDirection();

            StringAssert.StartsWith(result, "For");
        }



        #endregion


        #region CollectionAssert

        // object is part of a list. 
        [TestMethod]
        public void GetAllStoreCars_AddCarToList_Contains()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            var carStore = new CarStore(new List<Car> { car1, car2, car3 });

            var cars = carStore.GetAllStoreCars();

            CollectionAssert.Contains(cars, car1);
        }

        // list is part of another list
        [TestMethod]
        public void AddCars_AddCarList_IsSubset()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            List<Car> subsetCars = new List<Car>() { car1, car2 };
            var carStore = new CarStore(new List<Car> { car3 });

            carStore.AddCars(subsetCars);

            CollectionAssert.IsSubsetOf(subsetCars, carStore.Cars);
        }

        #endregion
    }
}
