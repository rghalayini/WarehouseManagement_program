using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public class Semi :Vehicle
    {
        public Semi() 
            : base (10) { }

        public string description
        {
            get
            {
                return "Semi capacity is " + Capacity;
            }
        }
    }
}
