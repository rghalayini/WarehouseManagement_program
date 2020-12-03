using System;
using StorageMaster.Models.Storages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Storage CreatedStorage;
            switch (type) 
            {
                case "Warehouse":
                    CreatedStorage = new Warehouse(name);
                    break;
                case "AutomatedWarehouse":
                    CreatedStorage = new AutomatedWarehouse(name);
                    break;
                case "DistributionCenter":
                    CreatedStorage = new DistributionCenter(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }           
            return CreatedStorage;
        }
    }
}
