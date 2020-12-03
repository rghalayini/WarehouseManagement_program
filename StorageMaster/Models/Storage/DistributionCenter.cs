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
    class DistributionCenter : Storage
    {
        private const int DistributionCenterCapacity = 2;
        private const int WDistributionCenterSlots = 5;

        private static Vehicle[] DefaultVehicles =
            { new Van(),
              new Van(),
              new Van()};

        //the below is just to test the creation of a storage. It is not necessary in this exercise
        public DistributionCenter(string name)
            : base(name,
                   DistributionCenterCapacity,
                   WDistributionCenterSlots,
                   DefaultVehicles)
        { }
    }  
}
