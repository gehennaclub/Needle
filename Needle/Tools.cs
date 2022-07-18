using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle
{
    public class Tools
    {
        public static string dbac(byte[] bytes)
        {
            string buffer = "{ ";

            foreach (byte b in bytes)
            {
                buffer += $"{(char)b}";
            }
            buffer += " }";

            return (buffer);
        }

        public static string dbab(byte[] bytes)
        {
            string buffer = "";

            foreach (byte b in bytes)
            {
                buffer += $"{b}";
            }

            return (buffer);
        }
    }
}
