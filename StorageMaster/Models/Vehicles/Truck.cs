using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const int DefaultCapacityValue = 5;

        public Truck() 
            : base(DefaultCapacityValue) { }

        //the below is just to test the creation of a vehicle. It is not necessary in this exercise
        public string description
        {
            get
            {
                return "Truck capacity is " + Capacity;
            }
        }
    }
}
