using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Storage NewStorage;

            if (type == "Warehouse") { NewStorage = new Warehouse(name); }
            else if (type == "AutomatedWarehouse") { NewStorage = new AutomatedWarehouse(name); }
            else if (type == "DistributionCenter") { NewStorage = new DistributionCenter(name); }
            else { throw new InvalidOperationException("Invalid storage type!"); }
            
            return NewStorage;
        }
    }
}
