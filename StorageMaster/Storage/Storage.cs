using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
{
    public abstract class Storage 
    {
        private Vehicle[] VehicleInGarage;
        private List<Product> StorageProducts = new List<Product>();
        //public Vehicle currentVehicle;


        public string Name { get; set; }
        public int Capacity { get; set; }
        public int GarageSlots { get; set; }
        public bool IsFull
        {
            get
            {
                var productsWeight = 0.0;
                foreach (var vehicle in Garage)
                {
                    foreach (var product in vehicle.Trunk)
                    {
                        productsWeight += product.Weight;
                    }
                }
                return productsWeight >= Capacity;
            }
        }

        public readonly IReadOnlyCollection<Vehicle> Garage;
        public readonly IReadOnlyCollection<Product> Products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles) //delete IEnumerable and replace it with vehicle
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.Garage = new Vehicle[GarageSlots]; //corrected here 
            this.Products = new Product[] { };

        }

        // -- Methods to use -- 


        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("InValid garage slot!");
            }
            else if (Garage.ElementAt(garageSlot) == null)
            {
                throw new InvalidOperationException("No vehicle in this slot!");
            }
            return Garage.ElementAt(garageSlot);
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var sentVehicle = GetVehicle(garageSlot);

            var FreeSlotInGarage = deliveryLocation.Garage.Any(p => p == null);
            if (FreeSlotInGarage == false)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            VehicleInGarage[garageSlot] = null;
            int FreedSlot = Convert.ToInt32(VehicleInGarage[garageSlot]);
            return FreedSlot;       
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull) throw new InvalidOperationException("Storage is full!");

            var VehicleToGet = GetVehicle(garageSlot);
            var UnloadedProducts = 0;
            
            while (!IsFull && !VehicleToGet.IsEmpty)
            {
                var temp = VehicleToGet.UnLoad();
                StorageProducts.Add(temp);
                UnloadedProducts++;
            }
            return UnloadedProducts;
        }
    }
}
