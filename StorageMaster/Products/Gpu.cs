using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public class Gpu : Product
    {
        public Gpu(double Price)
            : base(Price, 0.7) { }

        public string description
        {
            get
            {
                return "Gpu cost is " + Price + "$ and weighs " + Weight + " Kg.";
            }
        }
    }

}
