using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster_tests
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void SemiTest()
        {
            //-- Arrange
            Semi semi1 = new Semi();
            
            string expected = "Semi capacity is 10";

            //-- Act
            string actual = semi1.description;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TruckTest()
        {
            //-- Arrange
            Truck truck1 = new Truck();

            string expected = "Truck capacity is 5";

            //-- Act
            string actual = truck1.description;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void VanTest()
        {
            //-- Arrange
            Van van1 = new Van();

            string expected = "Van capacity is 2";

            //-- Act
            string actual = van1.description;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
