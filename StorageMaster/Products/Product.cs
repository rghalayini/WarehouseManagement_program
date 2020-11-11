using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public abstract class Product 
    {
        private double price;
 
        public double Price 
        {
            get { return price; }
            set
            {
                if (value <0)
                {
                    throw new InvalidOperationException("Price cannot be negative");
                }
                this.price = value;
            }               
        }
        public double Weight { get; set; }

        public Product (double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
    }
}