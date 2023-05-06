using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CarAPITests
{
    [TestClass]
    public class ServiceTestLab
    {

        private static Mock<IOwnersRepository> _ownersRepositoryMock;
        private static Mock<ICarsRepository> _carsRepositoryMock;
        private static Mock<IPaymentService> _paymentServiceMock;

        private static CarsService _carsService;
        private static OwnersService _ownersService;

        [ClassInitialize]
        public static void CreateOwnerService(TestContext context)
        {
            _ownersRepositoryMock = new Mock<IOwnersRepository>();
            _carsRepositoryMock = new Mock<ICarsRepository>();
            _paymentServiceMock = new Mock<IPaymentService>();

            _carsService = new CarsService(_carsRepositoryMock.Object);
            _ownersService = new OwnersService(_ownersRepositoryMock.Object, _carsRepositoryMock.Object, _paymentServiceMock.Object);
        }

        [TestMethod]
        public void GetAll_ReturnAllCars_CarList()
        {
            // Arrange
            var carsList = new List<Car>() {
                new Car(1,CarType.Audi,20),
                new Car(2,CarType.BMW,50),
                new Car(3,CarType.BMW,10)};


            _carsRepositoryMock.Setup(m => m.GetAllCars()).Returns(carsList);

            var expected = 3; 
            // Act
            var result = _carsService.GetAll();

           
            // Assert
            Assert.AreEqual(expected,result.Count);
        }

        [TestMethod]
        public void AddCar_AddCarToList_True()
        {
            // Arrange
            var carsList = new List<Car>() {
                new Car(1,CarType.Audi,20),
                new Car(2,CarType.BMW,50),
                new Car(3,CarType.BMW,10)};

            var car = new Car(4, CarType.BMW, 10);

            _carsRepositoryMock.Setup(m => m.AddCar(car)).Returns(true);

            // Act
            var result = _carsService.AddCar(car);


            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Remove_RemoveCarToList_True()
        {
            // Arrange
            var carsList = new List<Car>() {
                new Car(1,CarType.Audi,20),
                new Car(2,CarType.BMW,50),
                new Car(3,CarType.BMW,10)};

            var CarId = 1;

            _carsRepositoryMock.Setup(m => m.Remove(CarId)).Returns(true);


            // Act
            var result = _carsService.Remove(CarId);

            // Assert
            Assert.IsTrue(result);

        }
    }
}
