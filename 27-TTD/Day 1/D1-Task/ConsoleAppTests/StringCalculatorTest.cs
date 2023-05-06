using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTests
{

    [TestClass]
    public class StringCalculatorTest
    {
        // ok
        [TestMethod]
        public void Add_EmptyString_Return0()
        {
            var testingNumber = "";
            var expected = 0;

            var result = StringCalculator.Add(testingNumber);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_SignleNumber_ReturnNumber()
        {
            var testingNumber = "1";
            var expected = 1;

            var result = StringCalculator.Add(testingNumber);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_NumbersSequence_ReturnSum()
        {
            var testingNumber = "1,1,1";
            var expected = 3;

            var result = StringCalculator.Add(testingNumber);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_AcceptOtherDelimeters_ReturnSum()
        {
            var testingNumber = "1\n2,3";
            var expected = 6;

            var result = StringCalculator.Add(testingNumber);

            Assert.AreEqual(expected, result);
        }

        // method 1

        [TestMethod]
        public void Add_MultipleNegativeNumbers_ThrowException()
        {
            var testingNumber = "-1,-2";
            var expected = "Negatives not allowed: -1, -2";

            var result = Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add(testingNumber));  

            Assert.AreEqual(expected, result.Message);
        }

        // method 2 which is better? ok 

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negatives not allowed: -1, -2")]  
        public void Add_MultipleNegativeNumbers_ThrowException_UsingExceptionAttribute()
        {
            var testingNumber = "-1,-2";
            StringCalculator.Add(testingNumber);
        }

    }
}
