

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public abstract class VehicleFactory
    {
        public Vehicle CreateVehicle(int capacity)
        {
            Vehicle NewVehicle;

            if (capacity == 2) { NewVehicle = new Van(); }
            else if (capacity == 5) { NewVehicle = new Truck(); }
            else if (capacity == 10) { NewVehicle = new Semi(); }
            else { throw new InvalidOperationException("Invalid vehicle type!"); }

            return NewVehicle;
        }

    }
}
