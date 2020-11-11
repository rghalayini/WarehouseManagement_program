using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public class HardDrive : Product
    {
        public HardDrive(double Price)
            : base(Price, 1) { }

        public string description
        {
            get
            {
                return "HardDrive cost is " + Price + "$ and weighs " + Weight + " Kg.";
            }
        }
    }



    //public HardDrive(double price, double weight) : base(price, weight)
    //{ }
    //public const double HardDrive = 0.1;
}
