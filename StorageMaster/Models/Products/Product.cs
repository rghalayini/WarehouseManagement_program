using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Models.Products
{
    public abstract class Product 
    {
        private double price;

        public Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price 
        {
            get { return this.price; }
            set
            {
                if (value <0)
                {
                    throw new InvalidOperationException("Price cannot be negative");
                }
                this.price = value;
            }               
        }
        public double Weight { get; private set; }


    }
}