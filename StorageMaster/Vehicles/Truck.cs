using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public class Truck : Vehicle
    {
        public Truck() 
            : base(5) { }

        public string description
        {
            get
            {
                return "Truck capacity is " + Capacity;
            }
        }
    }
}
