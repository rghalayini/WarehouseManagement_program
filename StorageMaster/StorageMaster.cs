﻿using System;
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
        //public IDictionary<string, double> ProductPool = new Dictionary<string, double>();
        public IDictionary<string, Product> ProductPool = new Dictionary<string, Product>();

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
        Storage StorageOptions; // we need it here to access storage locations
        Product ProductsAvailable; 


        public string AddProduct(string type, double price)
        {
            if (!ProductTypes.Contains(type))
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            ProductFactory productfactory = null;
            var product = productfactory.CreateProduct(type, price);

            //ProductPool.Add(type, price);       CHECK THIS VERY IMPORTANT ---------------------------------------------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!

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

            StorageRegistry[storage.Name] = storage;
            //StorageRegistry.Add(type, name);

            //if (type == "Warehouse") { StorageOptions = new Warehouse(name); }
            //else if (type == "AutomatedWarehouse") { StorageOptions = new AutomatedWarehouse(name); }
            //else if (type == "DistributionCenter") { StorageOptions = new DistributionCenter(name); }
            //else { throw new InvalidOperationException("Invalid storage type!"); }

            //StorageRegistry.Add(type, name);

            ////var storage = Storage
            //if (!StorageTypes.Contains(type))
            //{
            //    throw new InvalidOperationException("Invalid storage type!");
            //}
            ////StorageRegistry.Add(type, name);

            return $"Registered {name}.";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            currentVehicle = StorageOptions.GetVehicle(garageSlot);

            string type;

            if (StorageRegistry.FirstOrDefault(x => x.Value == storageName).Key == "Semi")
            { type = "Semi"; }
            else if (StorageRegistry.FirstOrDefault(x => x.Value == storageName).Key == "Truck")
            { type = "Truck"; }
            else
            { type = "Van"; }

            return $"Selected {type}.";
        }
        
        public string LoadVehicle(IEnumerable<string> productNames)
        {
            //var VehicleToLoad = currentVehicle;
            int loadedProductsCount = 0;
            foreach (var name in productNames)
            {
                if (currentVehicle.IsFull) break;
                else if (!ProductPool.ContainsKey(name))  
                {
                    throw new InvalidOperationException($"{name} is out of stock!");
                }
                else
                {
                    var item = this.ProductPool[name];
                    currentVehicle.LoadProduct(item);
                }
                loadedProductsCount++;
                ProductPool.Remove(name);
            }
            return $"Loaded { loadedProductsCount}/{ productNames.Count()} products into { currentVehicle.GetType() }";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!StorageRegistry.ContainsKey(sourceName))
            { throw new InvalidOperationException("Invalid source storage!"); }
            if (!StorageRegistry.ContainsKey(destinationName))
            { throw new InvalidOperationException("Invalid destination storage!"); }

            var sourceStorage = StorageRegistry[sourceGarageSlot];
            var desintationStorage = StorageRegistry[destinationName];

            var destinationGarageSlot = sourceStorage;


            return $"Sent {currentVehicle.GetType()} to {destinationName} (slot {destinationGarageSlot}.)";        
        }

        //public string UnloadVehicle(string storageName, int garageSlot)
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetStorageStatus(string storageName)
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetSummary()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
