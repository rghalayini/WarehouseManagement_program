using StorageMaster;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Storages
{
    class Warehouse : Storage
    {
        private const int WarehouseCapacity = 10;
        private const int WarehouseGarageSlots = 10;

        // let's create 3 Semi as Default Vehicles
        private static Vehicle[] DefaultVehicles = 
            { new Semi(),
              new Semi(),
              new Semi()};

//the below is just to test the creation of a storage. It is not necessary in this exercise
        public Warehouse(string name)
            : base(name,
                   WarehouseCapacity,
                   WarehouseGarageSlots,
                   DefaultVehicles) { }
    }
}
