using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public abstract class Vehicle
    {
        public int Capacity { get; set; }

        public IReadOnlyCollection<Product> Trunk;  //Claes


        // CLAES
        public bool IsFull
        {
            get
            {
                double sum = this.Trunk.Sum(t => t.Weight);
                return sum >= Capacity;
            }
        }
        public bool IsEmpty  //CLAES
        {
            get
            {
                return Trunk.Count == 0;
            }
        }

        private List<Product> products;

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            Trunk = new List<Product>(); //Claes

            this.products = new List<Product>();
        }

        public void LoadProduct(Product product)  //ClAES
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full");
            }
            //var products = new List<Product>();   //removed this and put list outside
            //foreach (var item in Trunk)
            //{
            //    products.Add(item);
            //}
            products.Add(product);
            //Trunk = new ReadOnlyCollection<Product>(products);
        }

        public Product UnLoad()  //Claes
        {
            if (IsEmpty)
            {
                return default(Product);
            }
            //var products = new List<Product>(); //removed this and put list outside
            foreach (var item in Trunk)
            {
                products.Add(item);
            }
            var removeItem = products[products.Count - 1];
            products.RemoveAt(products.Count - 1);
            Trunk = new ReadOnlyCollection<Product>(products);
            return removeItem;
        }

        
        //public IReadOnlyCollection<Product> Trunk
        //{
        //    get { return this.ProductList; }
        //    //get { return this.ProductList.AsReadOnly(); } //if we want it to be immutable
        //}
        ////public bool IsFull => this.Trunk.Sum(p => p.Weight) >= this.Capacity;




        //REMY
        //public bool IsFull()
        //{
        //    var Full = true;
        //    double sum = this.Trunk.Sum(t => t.Weight);
        //    if (sum >= this.Capacity) Full = true;
        //    return Full;
        //}
        //public bool IsEmpty => this.Trunk.Count == 0;



        ////Methods
        //public void LoadProduct(Product product)
        //{
        //    if (IsFull == true)
        //    { throw new InvalidOperationException("Vehicle is full!"); }
        //    this.ProductList.Add(product);
        //}


        //public Product Unload()
        //{
        //    if (this.IsEmpty == true)
        //    { throw new InvalidOperationException("No products left in vehicle!"); }
        //    //write the else 
        //    var removeItem = ProductList[ProductList.Count - 1];
        //    ProductList.RemoveAt(ProductList.Count - 1);
        //    return removeItem;
        //}
    }
}
