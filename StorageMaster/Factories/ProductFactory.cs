using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Product CreatedProduct;
            switch (type)
            {
                case "Ram":
                    CreatedProduct = new Ram(price);
                    break;
                case "Gpu":
                    CreatedProduct = new Gpu(price);
                    break;
                case "HardDrive":
                    CreatedProduct = new HardDrive(price);
                    break;
                case "SolidStateDrive":
                    CreatedProduct = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }
            return CreatedProduct;
        }
    }
}
