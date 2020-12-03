using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Vehicles
{
    public class Van : Vehicle
    {
        private const int DefaultCapacityValue = 2;

        public Van () 
            : base (DefaultCapacityValue) { }

        //the below is just to test the creation of a vehicle. It is not necessary in this exercise
        public string description
        {
            get
            {
                return "Van capacity is " + Capacity;
            }
        }
    }
}
