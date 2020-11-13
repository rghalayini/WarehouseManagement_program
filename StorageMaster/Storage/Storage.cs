using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
{
    public abstract class Storage 
    {
        private Vehicle[] garage;
        private List<Product> StorageProducts = new List<Product>();

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int GarageSlots { get; set; }
        public bool IsFull
        {
            get
            {
                var productsWeight = 0.0;
                foreach (var vehicle in garage)
                {
                    if (vehicle != null)
                    {
                        foreach (var product in vehicle.Trunk)
                        {
                            productsWeight += product.Weight;
                        }
                    }
                }
                return productsWeight >= Capacity;
            }
        }

        //public readonly IReadOnlyCollection<Vehicle> Garage;
        public IReadOnlyCollection<Product> Products;
        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[GarageSlots]; //corrected here 
            this.Products = new Product[] { };
            this.DefaultVehiclesInGarage(vehicles);
        }
        private void DefaultVehiclesInGarage(IEnumerable<Vehicle> vehicles)
        {
            {
                int i = 0;
                foreach (var vehicle in vehicles)
                {
                    this.garage[i++] = vehicle;
                }
            }       
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

            if (!deliveryLocation.Garage.Any(p => p == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }
   
            {
                int slot = 0;
                List<Vehicle> vehiclesInGarage = deliveryLocation.Garage.ToList();
                for (int i = 0; i < vehiclesInGarage.Count; i++)
                {
                    if (vehiclesInGarage[i] == null)
                    {
                        vehiclesInGarage[i] = sentVehicle;
                        slot = i;
                        break;
                    }
                    //Garage = new ReadOnlyCollection<Vehicle>(vehiclesInGarage);
                }
                return slot;
            }
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
