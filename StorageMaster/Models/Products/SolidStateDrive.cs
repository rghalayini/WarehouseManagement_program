using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Products
{
    public class SolidStateDrive : Product
    {
        private const double DefaultWeight = 0.2;

        public SolidStateDrive(double Price)
            : base(Price, DefaultWeight) { }

        //the below is just to test the creation of a product. It is not necessary in this exercise
        public string description
        {
            get
            {
                return "SSD cost is " + Price + "$ and weighs " + Weight + " Kg.";
            }
        }
    }
}
