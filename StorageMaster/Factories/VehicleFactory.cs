using System;
using StorageMaster.Models.Vehicles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Factories
{
    public abstract class VehicleFactory
    {
        public Vehicle CreateVehicle(int capacity)
        {
            Vehicle CreatedVehicle;
            switch (capacity)
            {
                case 2:
                    CreatedVehicle = new Van();
                    break;
                case 5:
                    CreatedVehicle = new Truck();
                    break;
                case 10:
                    CreatedVehicle = new Semi();
                    break;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }
            return CreatedVehicle;
        }
    }
}
