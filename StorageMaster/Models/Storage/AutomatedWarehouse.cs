using System;
using StorageMaster;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int AtomatedWarehouseCapacity = 1;
        private const int AutomatedWarehouseGarageSlots = 2;

        public static Vehicle[] DefaultVehicles =
            { new Truck() };

        public AutomatedWarehouse(string name)
            : base(name,
                   AtomatedWarehouseCapacity,
                   AutomatedWarehouseGarageSlots,
                   DefaultVehicles) { }

        //the below is just to test the creation of a storage. It is not necessary in this exercise
        public string Description
        {
            get
            {
                return "AW name is " + Name + 
                    ", has a capacity of " + Capacity + 
                    ", has " + GarageSlots +
                    " garageslots and contains " + DefaultVehicles
                     + " vehicles.";
            }
        }
    }
}
