using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StorageMaster;

namespace StorageMaster
{
    public class StorageMaster
    {   
        List<Product> ProductPool = new List<Product>();
        //List<Storage> StorageRegistry = new List<Storage>();

        private List<string> ProductTypes = new List<string>()
        {
            "Gpu",
            "HardDrive",
            "Ram",
            "SolidStateDrive"
        };

        public IDictionary<string, Storage> StorageRegistry = new Dictionary<string, Storage>();
       
        private List<string> StorageTypes = new List<string>()
        {
            "Warehouse",
            "Distribution Center",
            "Automated Warehouse"
        };

        private Vehicle currentVehicle; //we need to use it here
       
        public string AddProduct(string type, double price)
        {
            if (!ProductTypes.Contains(type))
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            ProductFactory productfactory = null;
            var product = productfactory.CreateProduct(type, price);

            ProductPool.Add(product);
            return $"Added {type} to pool.";
        }

        public string RegisterStorage(string type, string name)
        {
            if (!StorageTypes.Contains(type))
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            StorageFactory storagefactory = null;
            var storage = storagefactory.CreateStorage(type, name);

            StorageRegistry.Add(name, storage);       

            return $"Registered {name}.";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = StorageRegistry[storageName];
            currentVehicle = storage.GetVehicle(garageSlot);    
            
            return $"Selected {currentVehicle.GetType()}.";
        }
        
        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;
            foreach (var name in ProductPool)    //(var name in productNames)
            {   
                if (currentVehicle.IsFull) break;
                else if (!ProductPool.Contains(name))
                    throw new InvalidOperationException($"{name} is out of stock!");               
                else
                {
                    ProductPool.Remove(name);
                    currentVehicle.LoadProduct(name);
                }
                loadedProductsCount++;
            }
            return $"Loaded { loadedProductsCount}/{ productNames.Count()} products into { currentVehicle.GetType() }";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!StorageRegistry.ContainsKey(sourceName))
            { throw new InvalidOperationException("Invalid source storage!"); }
            if (!StorageRegistry.ContainsKey(destinationName))
            { throw new InvalidOperationException("Invalid destination storage!"); }

            var vehicle = SelectVehicle(sourceName, sourceGarageSlot);
            var sourceStorage = StorageRegistry[sourceName];
            var destinationStorage = StorageRegistry[destinationName];

            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage) ;

            return $"Sent {vehicle.GetType()} to {destinationName} (slot {destinationGarageSlot}.)";        
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = StorageRegistry[storageName];
            var productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);
            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}.";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = StorageRegistry[storageName];
            var productsCount = storage.Products.Count;

            var AvailableStock = storage.Products
                                 .GroupBy(f => f.GetType().Name)
                                 .OrderByDescending(g => g.Count())
                                 .ThenBy(h => h.Key);

            List<string> GarageVehicles = new List<string>();
            foreach (var vehicle in storage.Garage)
            {
                if (vehicle == null)
                    GarageVehicles.Add("empty");
                else
                    GarageVehicles.Add(vehicle.GetType().Name);
            }


            //AvailableStock



            IEnumerable<Product> products = storage.Products.ToArray();
            /*products.OrderBy<int, Product>(p => p.GetType()).
                GroupBy(p => p.Name).ToList();
            return "Stock ({0}/{1}): [{2}]\n, { productsCount}, productsCount, productsCount"; 
                + "Garage: [{0}]";*/


            return "string";
        }

        public string GetSummary()
        {
            var s = "";
            foreach (var item in ProductPool)
            {
                //s += "Name: " + item.name + "\n";

                var storageName = StorageRegistry.Keys;
                var storageWorth = 1;
            }
            return s;
        }
    }
}
