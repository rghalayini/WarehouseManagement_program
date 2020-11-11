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
    public class StorageTest
    {
        [TestMethod]
        public void AutomatedWarehouseTest()
        {
            //-- Arrange
            AutomatedWarehouse AW1 = new AutomatedWarehouse("Brooklyn");

            string expected = "AW name is Brooklyn, has a capacity of 1, has 2 garageslots and contains 1 vehicles.";

            //-- Act
            string actual = AW1.description;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
