using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Product CreatedProduct;

            if (type == "Gpu") { CreatedProduct = new Gpu(price); }
            else if (type == "HardDrive") { CreatedProduct = new HardDrive(price); }
            else if (type == "Ram") { CreatedProduct = new Ram(price); }
            else if (type == "SolidStateDrive") { CreatedProduct = new SolidStateDrive(price); }
            else { throw new InvalidOperationException("Invalid product type!"); }

            return CreatedProduct;
        }
    }
}
