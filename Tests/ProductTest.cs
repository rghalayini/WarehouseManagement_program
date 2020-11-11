using System;
using StorageMaster;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StorageMaster_tests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void GpuTest()
        {
            //-- Arrange
            Gpu gpu1 = new Gpu(10);

            string expected = "Gpu cost is 10$ and weighs 0,7 Kg.";

            //-- Act
            string actual = gpu1.description;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HardDriveTest()
        {
            //-- Arrange           
            HardDrive HD1 = new HardDrive(20);

            string expected = "HardDrive cost is 20$ and weighs 1 Kg.";

            //-- Act
            string actual = HD1.description;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RamTest()
        {
            //-- Arrange           
            Ram ram1 = new Ram(10);

            string expected = "Ram cost is 10$ and weighs 0,1 Kg.";

            //-- Act
            string actual = ram1.description;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SolidStateDriveTest()
        {
            //-- Arrange           
            SolidStateDrive ssd1 = new SolidStateDrive(30);

            string expected = "SSD cost is 30$ and weighs 0,2 Kg.";

            //-- Act
            string actual = ssd1.description;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
