using CarAPI.Entities;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace CarAPITests
{
    [TestClass]
    public class RepoTestLab
    {
        // The only thing injected in the repo is the context. 
        // That's why we only `mock` the context. 
        private static Mock<InMemoryContext> _InMemoryContextMock;

        private static CarsRepository _CarRepository;
        private static OwnersRepository _OwnersRepository;



        [ClassInitialize]
        public static void CreateOwnerService(TestContext context)
        {
            _InMemoryContextMock = new Mock<InMemoryContext>();

            _CarRepository = new CarsRepository(_InMemoryContextMock.Object);
            _OwnersRepository = new OwnersRepository(_InMemoryContextMock.Object);

        }




        [TestMethod]
        public void GetAllCars_ReturnsAllCars_Equal()
        {
            // Arrange

            var carsList = new List<Car>() {
                new Car(1,CarType.Audi,20),
                new Car(2,CarType.BMW,50),
                new Car(3,CarType.BMW,10)};


            _InMemoryContextMock.Setup(c => c.Cars).Returns(carsList);


            var expected = 3; 

            // Act
            var result = _CarRepository.GetAllCars();

            // Assert

            Assert.AreEqual(expected, result.Count);
        }


        [TestMethod]
        public void AddCar_AddCarToList_IncreaseBy1()
        {
            // Arrange

            var carsList = new List<Car>() {
                new Car(1,CarType.Audi,20),
                new Car(2,CarType.BMW,50),
                new Car(3,CarType.BMW,10)};

            var car = new Car(4, CarType.BMW, 10);

            _InMemoryContextMock.Setup(c => c.Cars).Returns(carsList);

            var expected = 4;

            // Act
            var result = _CarRepository.AddCar(car);

            // Assert

            Assert.AreEqual(expected, carsList.Count);
        }


        [TestMethod]
        public void Remove_RemoveCarFromList_DecreaseBy1()
        {
            // Arrange

            var carsList = new List<Car>() {
                new Car(1,CarType.Audi,20),
                new Car(2,CarType.BMW,50),
                new Car(3,CarType.BMW,10)};

            _InMemoryContextMock.Setup(c => c.Cars).Returns(carsList);

            var expected = 2;

            var CarId = 1; 

            // Act
            var result = _CarRepository.Remove(CarId);

            // Assert

            Assert.AreEqual(expected, carsList.Count);
        }




    }
}
