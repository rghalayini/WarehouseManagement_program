using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public class Ram : Product
    {
        public Ram(double Price)
            : base(Price, 0.1) { }

        public string description
        {
            get
            {
                return "Ram cost is " + Price + "$ and weighs " + Weight + " Kg.";
            }
        }
    }

    //public Ram(double price, double weight) : base(price, weight)
    //{ }
    //public const double RamWeight = 0.1;
}
