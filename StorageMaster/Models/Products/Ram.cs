using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Products
{
    public class Ram : Product
    {
        private const double DefaultWeight = 0.1;

        public Ram(double Price)
            : base(Price, DefaultWeight) { }

        //the below is just to test the creation of a product. It is not necessary in this exercise
        public string description
        {
            get
            {
                return "Ram cost is " + Price + "$ and weighs " + Weight + " Kg.";
            }
        }
    }
}
