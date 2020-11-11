using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public class SolidStateDrive : Product
    {
        public SolidStateDrive(double Price)
            : base(Price, 0.2) { }

        public string description
        {
            get
            {
                return "SSD cost is " + Price + "$ and weighs " + Weight + " Kg.";
            }
        }
    }

    //public SolidStateDrive(double price, double weight) : base(price, weight)
    //{ }
    //public const double SSDWeight = 1;
}
