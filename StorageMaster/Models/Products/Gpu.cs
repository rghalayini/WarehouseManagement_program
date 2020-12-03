using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Products
{
    public class Gpu : Product
    {
        private const double DefaultWeight = 0.7;

        public Gpu(double Price)
            : base(Price, DefaultWeight) { }

        //the below is just to test the creation of a product. It is not necessary in this exercise
        public string description
        {
            get
            {
                return "Gpu cost is " + Price + "$ and weighs " + Weight + " Kg.";
            }
        }
    }

}
