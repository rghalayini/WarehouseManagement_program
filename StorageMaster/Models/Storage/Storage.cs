using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage 
    {
        private readonly List<Product> products;
        private readonly Vehicle[] garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[GarageSlots]; //corrected here 
            this.products = new List<Product>();
            this.DefaultVehiclesInGarage(vehicles);
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int GarageSlots { get; private set; }
        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;

        //This interface[IReadOnlyCollection] means that we only could enumrate through it. Not remove or add. 
        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();
        public IReadOnlyCollection<Vehicle> Garage => this.garage;





        // ----- Methods to use -----

        private void DefaultVehiclesInGarage(IEnumerable<Vehicle> vehicles)
        {           
            int i = 0;
            foreach (var vehicle in vehicles)
            {
                this.garage[i] = vehicle;
                i++;
            }
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("InValid garage slot!");
            }
            if (Garage.ElementAt(garageSlot) == null)
            {
                throw new InvalidOperationException("No vehicle in this slot!");
            }
            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var sentVehicle = GetVehicle(garageSlot);

            if (!deliveryLocation.Garage.Any(p => p == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;

            var addedSlot = deliveryLocation.AddVehicle(sentVehicle);

            return addedSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull) throw new InvalidOperationException("Storage is full!");

            var VehicleToGet = GetVehicle(garageSlot);
            var UnloadedProducts = 0;
            
            while (!IsFull && !VehicleToGet.IsEmpty)
            {
                var temp = VehicleToGet.UnLoad();
                this.products.Add(temp);
                UnloadedProducts++;
            }
            return UnloadedProducts;
        }
        private int AddVehicle(Vehicle vehicle)
        {
            var emptySlot = Array.IndexOf(this.garage, null);

            this.garage[emptySlot] = vehicle;

            return emptySlot;
        }
    }
}
