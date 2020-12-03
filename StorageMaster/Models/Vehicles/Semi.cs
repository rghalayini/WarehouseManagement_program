using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Vehicles
{
    public class Semi : Vehicle
    {
        private const int DefaultCapacityValue = 10;

        public Semi() 
            : base (DefaultCapacityValue) { }

        //the below is just to test the creation of a vehicle. It is not necessary in this exercise

        public string description
        {
            get
            {
                return "Semi capacity is " + Capacity;
            }
        }
    }
}
