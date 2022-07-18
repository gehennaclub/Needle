using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle.Client
{
    public class Validator
    {
        public static bool size(byte[] bytes, int minimum)
        {
            return (bytes.Length >= minimum);
        }

        public static bool size(byte[] bytes, int minimum, int maximum)
        {
            return (bytes.Length >= minimum && bytes.Length <= maximum);
        }
    }
}
