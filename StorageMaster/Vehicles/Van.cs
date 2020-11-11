using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    public class Van : Vehicle
    {
        public Van () 
            : base (2){ }

        public string description
        {
            get
            {
                return "Van capacity is " + Capacity;
            }
        }
    }
}
