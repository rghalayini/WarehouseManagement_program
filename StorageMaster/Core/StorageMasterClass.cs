using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Core
{
    public class StorageMasterClass
    {   
        //List<Product> ProductPool = new List<Product>();
        //List<Storage> StorageRegistry = new List<Storage>();
        public IDictionary<string, Stack<Product>> ProductPool = new Dictionary<string, Stack<Product>>();


        private readonly List<string> ProductTypes = new List<string>()
        {
            "Gpu",
            "HardDrive",
            "Ram",
            "SolidStateDrive"
        };

        public IDictionary<string, Storage> StorageRegistry = new Dictionary<string, Storage>();
       
        private readonly List<string> StorageTypes = new List<string>()
        {
            "Warehouse",
            "DistributionCenter",
            "AutomatedWarehouse"
        };


        private Vehicle currentVehicle; 

        public StorageFactory storagefactory = new StorageFactory();
        public ProductFactory productfactory = new ProductFactory();


        public string AddProduct(string type, double price)
        {
            if (!ProductTypes.Contains(type))
            {
                throw new InvalidOperationException("Invalid product type!");
            }
            else if (!ProductPool.ContainsKey(type))
            {
                ProductPool[type] = new Stack<Product>();
            }
            var product = this.productfactory.CreateProduct(type, price);

            this.ProductPool[type].Push(product);
            //ProductPool.Add(product);
            return $"Added {type} to pool.";
        }

        public string RegisterStorage(string type, string name)
        {
            if (!StorageTypes.Contains(type))
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            var storage = this.storagefactory.CreateStorage(type, name);

            StorageRegistry.Add(name, storage);       

            return $"Registered {name}.";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = StorageRegistry[storageName];
            this.currentVehicle = storage.GetVehicle(garageSlot);    
            
            return $"Selected {this.currentVehicle.GetType().Name}.";
        }
        
        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var name in productNames)  
            {
                if (currentVehicle.IsFull) break;
                else if (!ProductPool.ContainsKey(name) )
                    throw new InvalidOperationException($"{name} is out of stock!");
                else
                {
                    var RemovedProduct = ProductPool[name].Pop();
                    currentVehicle.LoadProduct(RemovedProduct);
                    loadedProductsCount++;
                }
            }
            return $"Loaded { loadedProductsCount}/{ productNames.Count()} products into { currentVehicle.GetType().Name }";


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

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot}.)";        
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = StorageRegistry[storageName];
            var productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);
            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}.";
        }
        //check this
        public string GetStorageStatus(string storageName)
        {
            var storage = StorageRegistry[storageName];
            var productsCount = storage.Products.Count;

            var StockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                productsCapacity,
                storage.Capacity,
                string.Join(", ", StockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            return stockFormat + Environment.NewLine + garageFormat;

        }
        //good
        public string GetSummary()
        {
            var AllStorages = StorageRegistry.Values
                .OrderBy(p => p.Products.Sum(f => f.Price))
                .ToList();

            var final = new StringBuilder();
            foreach (var storage in AllStorages)
            {
                final.Append($"{storage.Name}:");
                double totalMoney = storage.Products.Sum(p => p.Price);
                final.Append($"Storage Worth: {totalMoney:F2}");
            }           
            return final.ToString();
        }
    }
}
