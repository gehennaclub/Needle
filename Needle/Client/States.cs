using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle.Client
{
    public class States
    {
        public bool validated { get; set; }

        public States(bool validated)
        {
            this.validated = validated;
        }
    }
}
