using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageMaster;

namespace StorageMaster_tests
{
    [TestClass]
    public class StorageMasterClassMethods
    {
        [TestMethod]
        public void AddProductTest()
        {
            //-- Arrange
            string type = "Gpu";
            double price = 1200;
            string expected = "Added Gpu to pool.";

            //-- Act
            //string actual =.AddProduct(type, price); //$"Added {type} to pool.";

            //-- Assert
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegisterStorageTest()
        {
            //-- Arrange
            string type = "DistributionCenter ";
            string name = "SofiaDistribution";
            string expected = "Registered SofiaDistribution.";

            //-- Act
            var actual = StorageMasterClass.RegisterStorage(type, name);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
