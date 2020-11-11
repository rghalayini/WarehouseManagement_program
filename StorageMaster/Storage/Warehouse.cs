using StorageMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
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

        public Warehouse(string name)
            : base(name,
                   WarehouseCapacity,
                   WarehouseGarageSlots,
                   DefaultVehicles) { }
    }
}
